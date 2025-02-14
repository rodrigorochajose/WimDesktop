using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using DMMDigital.Properties;
using System.Text;
using System.Text.RegularExpressions;
using DMMDigital.Interface.IView;

namespace DMMDigital.Views
{
    public partial class MigrationDatabaseView : Form, IMigrationDatabaseView
    {
        private readonly string wimMigrationPath = @"C:\WimDesktopDB\migration\tools\";
        private readonly string dataPath = "";

        public string software { get; set; }
        public List<PatientModel> patients { get; set; } = new List<PatientModel>();
        public List<ExamModel> exams { get; set; } = new List<ExamModel>();
        public List<ExamImageModel> examImages { get; set; } = new List<ExamImageModel>();
        public List<ExamImageCDR> examImagesCDR { get; set; } = new List<ExamImageCDR>();

        public PatientModel patientToImport { get; set; }
        public ExamModel examToImport { get; set; }
        public List<ExamImageModel> examImagesToImport { get; set; } = new List<ExamImageModel>();
        public SettingsModel settingsToImport { get; set; }

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
                eventImportPatient?.Invoke(this, EventArgs.Empty);

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
            int totalPatients = patients.Count;

            foreach (PatientModel patient in patients)
            {
                int patientOldId = patient.id;

                List<ExamModel> patientExams = exams.Where(e => e.patientId == patient.id).ToList();

                patientToImport = patient;
                eventImportPatient?.Invoke(this, EventArgs.Empty);

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
                        int index = filePath.LastIndexOf('\\');

                        string examContentPath = Path.Combine(dataPath, filePath.Substring(0, index), "SR000001");

                        currentExamImages = getUsedImages(examContentPath, currentExamImages);

                        if (currentExamImages.Any())
                        {
                            patientExam.templateId = getTemplateId(examContentPath, currentExamImages.Count);

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
                processedPatients++;
                progress.Report((processedPatients * 100) / totalPatients);
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

            var lines = content.Split('à').Where(p => p.Contains("SCHICK TECHNOLOGIES"));

            List<string> imagesIdentifier = new List<string>();

            foreach (var line in lines)
            {
                Match match = Regex.Matches(line, @"\d+(\.\d+)*").Cast<Match>().FirstOrDefault(m => m.Length > 2);

                if (match != null)
                {
                    imagesIdentifier.Add(match.Value);
                }
            }

            currentExamImages = examImagesCDR.Where(ei => imagesIdentifier.Contains(ei.uid)).ToList();

            examImagesCDR.RemoveAll(ei => ei.examId == currentExamImages.First().examId);

            return currentExamImages.OrderBy(ei => ei.order).ToList();
        }

        private int getTemplateId(string path, int imagesCount)
        {
            string content = File.ReadAllText(path, Encoding.Default);

            int init = content.IndexOf("Sirona Dental");
            int final = content.IndexOf("CDR");

            string text = content.Substring(init, final - init);

            string resultClean = Regex.Replace(text, @"[^\x20-\x7E]", "");

            string[] parts = resultClean.Split(new string[] { "LO" }, StringSplitOptions.None);

            ITemplateRepository templateRepository = new TemplateRepository();

            List<TemplateModel> templates = templateRepository.getAllTemplates();

            TemplateModel matchedTemplate = findMatch(parts, templates);

            if (matchedTemplate != null)
            {
                return matchedTemplate.id;
            }
            else
            {
                if (imagesCount < 6)
                {
                    return 13;
                }
                else if (imagesCount < 16)
                {
                    return 14;
                }
                else
                {
                    return 15;
                }
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
            string folderDest = $"C:\\WimDesktopDB\\img\\{patientId}\\{examId}";

            if (!Directory.Exists(folderDest))
            {
                Directory.CreateDirectory(folderDest);
            }

            Directory.CreateDirectory(Path.Combine(folderDest, "recycle"));

            foreach (var examImage in examImages)
            {
                string originFile = Path.Combine(dataPath, examImage.file + ".jpeg");

                examImage.file = $"{examImage.order}_original.png";

                string dest = Path.Combine(folderDest, examImage.file);

                await Task.Run(() => File.Copy(originFile, dest, overwrite: true));
            }
        }
    }
}
