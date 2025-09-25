using FellowOakDicom;
using FellowOakDicom.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class MigrationDatabaseView : Form, IMigrationDatabaseView
    {
        private readonly string wimMigrationPath = @"C:\WimDesktopDB\migration\tools\";
        private readonly string dataPath = "";
        private string migrationErrors = "";

        public string software { get; set; }
        public List<PatientModel> patients { get; set; } = new List<PatientModel>();
        public List<ExamModel> exams { get; set; } = new List<ExamModel>();
        public List<ExamImageModel> examImages { get; set; } = new List<ExamImageModel>();
        public List<ExamImageCDR> examImagesCDR { get; set; } = new List<ExamImageCDR>();
        public PatientModel patientToImport { get; set; }
        public ExamModel examToImport { get; set; }
        public List<ExamImageModel> examImagesToImport { get; set; } = new List<ExamImageModel>();
        public SettingsModel settingsToImport { get; set; }
        public bool duplicatedPatient { get; set; }

        public event EventHandler eventImportPatient;
        public event EventHandler eventImportExam;
        public event EventHandler eventImportExamImages;
        public event EventHandler eventImportSettings;
        public event EventHandler eventGetDataToImport;

        public MigrationDatabaseView(string software, string path)
        {
            InitializeComponent();

            adjustUI();

            dataPath = path;
            this.software = software;

            Load += delegate
            {
                eventGetDataToImport?.Invoke(this, EventArgs.Empty);

                startProgressBar();
            };
        }

        private void adjustUI()
        {
            label.Text = Resources.messageGettingData;

            label.Left = (Width - label.Width) / 2;
        }

        private async void startProgressBar()
        {
            var progress = new Progress<int>(value =>
            {
                progressBar.Value = value;

                if (progressBar.Value >= progressBar.Maximum)
                {
                    if (!string.IsNullOrEmpty(migrationErrors))
                    {
                        File.WriteAllText(Path.Combine(@"C:\WimDesktopDB\migration", "migration_errors.txt"), migrationErrors);

                        MessageBox.Show("Houveram erros ao realizar a migração! Verificar os arquivos de logs!");
                        Close();
                        return;
                    }

                    MessageBox.Show(Resources.messageMigrationSuccess);

                    string[] directoriesToDelete = new string[]
                    {
                        @"C:\WimDesktopDB\migration\data",
                        Path.Combine(wimMigrationPath, "jdk-21.0.4"),
                        Path.Combine(wimMigrationPath, "h2")
                    };

                    foreach (string dir in directoriesToDelete)
                    {
                        if (Directory.Exists(dir))
                        {
                            Directory.Delete(dir, true);
                        }
                    }

                    Close();
                }
            });

            label.Text = Resources.messageImportData;
            adjustUI();

            await importDataAsync(progress);
        }

        private async Task importDataAsync(IProgress<int> progress)
        {
            int processedPatients = 0;

            if (software == "WIM")
            {
                await importData_WIM(progress, processedPatients);
            }
            else
            {
                await importData_CDR(progress, processedPatients);
            }
        }

        private async Task importData_WIM(IProgress<int> progress, int processedPatients)
        {
            int totalPatients = patients.Count;

            eventImportSettings?.Invoke(this, EventArgs.Empty);

            foreach (PatientModel patient in patients)
            {
                int patientOldId = patient.id;

                List<ExamModel> patientExams = exams.Where(e => e.patientId == patient.id).ToList();

                patientToImport = patient;
                duplicatedPatient = false;

                eventImportPatient?.Invoke(this, EventArgs.Empty);

                if (duplicatedPatient)
                {
                    processedPatients++;
                    progress.Report((processedPatients * 100) / totalPatients);
                    continue;
                }

                if (patientExams.Any())
                {
                    foreach (ExamModel patientExam in patientExams)
                    {
                        int examOldId = patientExam.id;
                        patientExam.patientId = patient.id;

                        List<ExamImageModel> patientExamImages = examImages.Where(ei => ei.examId == patientExam.id && File.Exists($@"{dataPath}\imgs\{patientOldId}\{examOldId}\{ei.file}")).ToList();

                        examToImport = patientExam;
                        eventImportExam?.Invoke(this, EventArgs.Empty);

                        patientExamImages = patientExamImages.Select(ei => new ExamImageModel
                        {
                            examId = patientExam.id,
                            templateFrameId = ei.templateFrameId,
                            file = ei.file,
                            notes = ei.notes,
                            createdAt = ei.createdAt
                        }).ToList();

                        if (patientExamImages.Any())
                        {
                            await importImages_WIM(patientOldId, patient.id, examOldId, patientExam.id);
                            examImagesToImport = patientExamImages;
                            eventImportExamImages?.Invoke(this, EventArgs.Empty);
                        }
                    }
                }
                processedPatients++;
                progress.Report((processedPatients * 100) / totalPatients);
            }
        }

        private async Task importData_CDR(IProgress<int> progress, int processedPatients)
        {
            try
            {
                int totalPatients = patients.Count;

                foreach (PatientModel patient in patients)
                {
                    int patientOldId = patient.id;

                    List<ExamModel> patientExams = exams.Where(e => e.patientId == patient.id).ToList();

                    patientToImport = patient;

                    duplicatedPatient = false;
                    eventImportPatient?.Invoke(this, EventArgs.Empty);

                    if (duplicatedPatient)
                    {
                        migrationErrors += $"[ALERTA] Paciente {patient.name} Duplicado.{Environment.NewLine}";

                        processedPatients++;
                        progress.Report((processedPatients * 100) / totalPatients);
                        continue;
                    }

                    if (patientExams.Any())
                    {
                        foreach (ExamModel patientExam in patientExams)
                        {
                            int examOldId = patientExam.id;

                            patientExam.patientId = patient.id;

                            List<ExamImageCDR> currentExamImages = examImagesCDR.Where(ei => ei.examId == patientExam.id).ToList();

                            if (!currentExamImages.Any())
                            {
                                continue;
                            }

                            string filePath = currentExamImages.First().file;
                            string examContentPath = Path.Combine(Path.Combine(dataPath, Path.GetDirectoryName(filePath)), "SR000001");

                            if (File.Exists(examContentPath))
                            {
                                currentExamImages = getUsedImages(examContentPath, currentExamImages);

                                if (!currentExamImages.Any())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                examContentPath = Path.Combine(dataPath, filePath);
                            }

                            if (currentExamImages.Any())
                            {
                                patientExam.templateId = getTemplateId(examContentPath, currentExamImages.Count);

                                if (patientExam.templateId == 0)
                                {
                                    continue;
                                }

                                examToImport = patientExam;
                                eventImportExam?.Invoke(this, EventArgs.Empty);

                                getTemplateFrameId(currentExamImages, patientExam.templateId);

                                await importImages_CDR(currentExamImages, patient.id, patientExam.id);

                                List<ExamImageModel> patientExamImages = convertExamImageModels(currentExamImages, patientExam.id);

                                examImagesToImport = patientExamImages;

                                eventImportExamImages?.Invoke(this, EventArgs.Empty);
                            }
                        }
                    }
                    else
                    {
                        migrationErrors += $"[ALERTA] Paciente {patient.name} não possui exames.{Environment.NewLine}";
                    }
                    processedPatients++;
                    progress.Report((processedPatients * 100) / totalPatients);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private List<ExamImageModel> convertExamImageModels(List<ExamImageCDR> examImages, int examId)
        {
            return examImages.Select(ei => new ExamImageModel
            {
                examId = examId,
                templateFrameId = ei.templateFrameId,
                file = ei.file,
                notes = ei.notes,
                createdAt = ei.createdAt
            }).ToList();
        }

        private List<ExamImageCDR> getUsedImages(string path, List<ExamImageCDR> currentExamImages)
        {
            string content = File.ReadAllText(path, Encoding.Default);

            var matches = Regex.Matches(content, @"\b\d+(\.\d+)+\b");

            HashSet<string> imagesIdentifier = new HashSet<string>();

            foreach (Match match in matches)
            {
                string uid = match.Value.Trim();
                if (!string.IsNullOrWhiteSpace(uid))
                {
                    imagesIdentifier.Add(uid);
                }
            }

            currentExamImages = examImagesCDR.Where(ei => imagesIdentifier.Contains(ei.uid)).ToList();

            if (!currentExamImages.Any())
            {
                return new List<ExamImageCDR>();
            }

            examImagesCDR.RemoveAll(ei => ei.examId == currentExamImages.First().examId);

            return currentExamImages.OrderBy(ei => ei.order).ToList();
        }

        private int getTemplateId(string path, int imagesCount)
        {
            try
            {
                string content = File.ReadAllText(path, Encoding.Default);

                string cleanContent = Regex.Replace(content, @"[^\x20-\x7E]", "");

                string[] keywords = new string[] { "BITEWINGS", "CENTRAL INFERIOR", "CENTRAL SUPERIOR", "CHECKUP", "ENDO HORIZONTAL (15)", "FULL MOUTH SERIES (18)", "FULL MOUTH SERIES (21)", "MANDIBULAR DIREITO", "MANDIBULAR ESQUERDO", "MAXILAR DIREITO", "MAXILAR DIREITO", "VERTICAL ENDO" };

                foreach (string keyword in keywords)
                {
                    if (cleanContent.Contains(keyword))
                    {
                        ITemplateRepository templateRepository = new TemplateRepository();
                        List<TemplateModel> templates = templateRepository.getAllTemplates();

                        TemplateModel matchedTemplate = findMatch(new string[] { keyword }, templates);
                        if (matchedTemplate != null)
                        {
                            return matchedTemplate.id;
                        }
                    }
                }

                if (imagesCount < 6)
                    return 13;
                else if (imagesCount < 16)
                    return 14;
                else
                    return 15;
            }
            catch (Exception ex)
            {
                migrationErrors += ex.Message + "\n\n";
                return 0;
            }
        }

        static TemplateModel findMatch(string[] inputs, List<TemplateModel> templates)
        {
            return templates.OrderByDescending(t => inputs.Max(input => calcSimilarity(input, t.name))).FirstOrDefault(m => inputs.Max(input => calcSimilarity(input, m.name)) > 0.5);
        }

        static double calcSimilarity(string input, string templateName)
        {
            var inputWords = extractWords(input);
            var templateNameWords = extractWords(templateName);

            int commonWords = templateNameWords.Count(p => inputWords.Contains(p, StringComparer.OrdinalIgnoreCase));

            long inputNumber = extractNumbers(input);
            long templateNameNumber = extractNumbers(templateName);

            double score = commonWords * 1.5;

            if (inputNumber == templateNameNumber && inputNumber > 0)
                score += 0.5;

            return score;
        }

        static IEnumerable<string> extractWords(string texto)
        {
            return texto.Split(new[] { ' ', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        }

        static long extractNumbers(string texto)
        {
            var match = Regex.Match(texto, @"\d+");
            return match.Success ? long.Parse(match.Value) : 0;
        }

        private void getTemplateFrameId(List<ExamImageCDR> examImages, int templateId)
        {
            ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

            List<TemplateFrameModel> templateFrames = templateFrameRepository.getTemplateFrame(templateId);

            foreach (var examImage in examImages)
            {
                TemplateFrameModel tfm = templateFrames.First(tf => tf.order == examImage.order);
                examImage.templateFrameId = tfm.id;
            }
        }

        private async Task importImages_WIM(int patientOldId, int patientId, int examOldId, int examId)
        {
            string[] files = Directory.GetFiles($@"{dataPath}\imgs\{patientOldId}\{examOldId}");

            string folderDest = $"C:\\WimDesktopDB\\img\\{patientId}\\{examId}";

            if (!Directory.Exists(folderDest))
            {
                Directory.CreateDirectory(folderDest);
            }

            Directory.CreateDirectory(Path.Combine(folderDest, "recycle"));

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);

                if (fileName.Contains("_original") || fileName.Contains("_filtered"))
                {
                    string dest = Path.Combine(folderDest, fileName);
                    await Task.Run(() => File.Copy(file, dest, overwrite: true));
                }
            }
        }

        private async Task importImages_CDR(List<ExamImageCDR> examImages, int patientId, int examId)
        {
            string folderDest = Path.Combine("C:\\WimDesktopDB\\img", patientId.ToString(), examId.ToString());

            Directory.CreateDirectory(folderDest);
            Directory.CreateDirectory(Path.Combine(folderDest, "recycle"));

            DicomConfig.EnsureConfigured();

            foreach (var examImage in examImages)
            {
                string originFile = Path.Combine(dataPath, examImage.file);

                if (!File.Exists(originFile))
                {
                    migrationErrors += $"[ERRO] Arquivo não encontrado: {originFile} (PatientId={patientId}, ExamId={examId}){Environment.NewLine}";
                    continue;
                }

                try
                {
                    await Task.Run(() => { 
                        string destFile = Path.Combine(folderDest, $"{examImage.order}_original.png");

                        var dicomFile = DicomFile.Open(originFile);
                        var dicomImage = new DicomImage(dicomFile.Dataset);

                        using (var rendered = dicomImage.RenderImage())
                        {
                            using (var bmp = rendered.AsSharedBitmap()){
                                bmp.Save(destFile, ImageFormat.Png);
                            }
                        }

                        examImage.file = destFile;
                    });
                }
                catch (Exception ex)
                {
                    migrationErrors += $"[ERRO] Falha ao processar {originFile}: {ex.Message} (PatientId={patientId}, ExamId={examId}){Environment.NewLine}";
                }
            }
        }
    }
}
