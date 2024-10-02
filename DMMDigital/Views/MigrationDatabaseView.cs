using CsvHelper.Configuration;
using CsvHelper;
using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;
using System.Diagnostics;
using System.Threading.Tasks;
using DMMDigital.Properties;


namespace DMMDigital.Views
{
    public partial class MigrationDatabaseView : Form
    { 
        private string migrationPath = @"C:\WimDesktopDB\migration\tools\";

        public MigrationDatabaseView(string database)
        {
            InitializeComponent();

            if (database == "WIM")
            {
                label.Text = Resources.messageGettingData;
                adjust();

                generateSQL();

                importData();
            }
            else
            {
                // cdr
            }
        }

        private void adjust()
        {
            label.Left = (Width - label.Width) / 2;
        }

        private void importData()
        {
            string javaPath = Path.Combine(migrationPath, @"jdk-21_windows-x64_bin\jdk-21.0.4\bin\java.exe");
            string h2Path = Path.Combine(migrationPath, @"h2-2019-10-14\h2\bin\h2-1.4.200.jar");
            string dbPath = $@"jdbc:h2:{Environment.GetEnvironmentVariable("USERPROFILE")}\.wimdesktop\db\wimdb";
            string scriptPath = Path.Combine(migrationPath, @"SQLGenerateCSV.sql");

            string command = $@"cd ""C:"" && ""{javaPath}"" -cp ""{h2Path}"" org.h2.tools.RunScript -url ""{dbPath}"" -user sa -password """" -script ""{scriptPath}""";

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {command}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = processStartInfo })
            {
                try
                {
                    process.Start();
                    process.WaitForExit();

                    startProgress();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            File.Delete(Path.Combine(migrationPath, @"SQLGenerateCSV.sql"));
        }

        private async void startProgress()
        {
            var progress = new Progress<int>(value =>
            {
                progressBar.Value = value;

                if (progressBar.Value >= progressBar.Maximum)
                {
                    MessageBox.Show(Resources.messageMigrationSuccess);

                    Directory.Delete(@"C:\WimDesktopDB\migration\data", true);
                    Close();
                }
            });

            await importDataAsync(progress);
        }

        private async Task importDataAsync(IProgress<int> progress)
        {
            label.Text = Resources.messageImportData;
            adjust();

            string dataPath = @"C:\WIMDesktopDB\migration\data";

            List<ConfigModel> configs = generateModel<ConfigModel, ConfigModelMap>(Path.Combine(dataPath, "config.csv"));
            configs[0].drawingColor = convertHexToARGB(configs[0].drawingColor);
            configs[0].textColor = convertHexToARGB(configs[0].textColor);
            configs[0].rulerColor = convertHexToARGB(configs[0].rulerColor);

            List<PatientModel> patients = generateModel<PatientModel, PatientModelMap>(Path.Combine(dataPath, "patient.csv"));
            List<ExamModel> exams = generateModel<ExamModel, ExamModelMap>(Path.Combine(dataPath, "exam.csv"));
            List<ExamImageModel> examImages = generateModel<ExamImageModel, ExamImageModelMap>(Path.Combine(dataPath, "exam_image.csv"));

            int totalPatients = patients.Count;
            int processedPatients = 0;

            IPatientRepository patientRepository = new PatientRepository();
            IExamRepository examRepository = new ExamRepository();
            IExamImageRepository examImageRepository = new ExamImageRepository();

            foreach (PatientModel patient in patients)
            {
                int patientOldId = patient.id;

                List<ExamModel> patientExams = exams.Where(e => e.patientId == patient.id).ToList();

                await Task.Run(() => patientRepository.importPatient(patient));

                if (patientExams.Any())
                {
                    foreach (ExamModel patientExam in patientExams)
                    {
                        int examOldId = patientExam.id;
                        patientExam.patientId = patient.id;

                        List<ExamImageModel> patientExamImages = examImages.Where(ei => ei.examId == patientExam.id).ToList();

                        await Task.Run(() => examRepository.addExam(patientExam));

                        if (patientExamImages.Any())
                        {
                            await Task.Run(() => patientExamImages.ForEach(ei => ei.examId = patientExam.id));
                            await Task.Run(() => examImageRepository.importExamImages(patientExamImages));
                        }

                        await importImagesAsync(patientOldId, patient.id, examOldId, patientExam.id);
                    }
                }
                processedPatients++;
                progress.Report((processedPatients * 100) / totalPatients);
            }
        }

        public static List<T> generateModel<T, TMap>(string caminhoArquivoCsv)
        where TMap : ClassMap<T>
        {
            using (var reader = new StreamReader(caminhoArquivoCsv))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<TMap>();
                var registros = csv.GetRecords<T>();
                return new List<T>(registros);
            }
        }

        public string convertHexToARGB(string hex)
        {
            hex = hex.Replace("#", "");

            hex = hex.Substring(0, hex.Length - 2);

            int argb = int.Parse(hex, NumberStyles.HexNumber);

            int alpha = 255;

            int red = (argb >> 16) & 0xFF;
            int green = (argb >> 8) & 0xFF;
            int blue = argb & 0xFF;

            int argbInt = (alpha << 24) | (red << 16) | (green << 8) | blue;

            return argbInt.ToString();
        }

        private async Task importImagesAsync(int patientOldId, int patientId, int examOldId, int examId)
        {
            string patientFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), $".wimdesktop\\imgs\\{patientOldId}");

            string[] files = Directory.GetFiles(Path.Combine(patientFolder, $"{examOldId}"));

            string folderDest = $"C:\\WimDesktopDB\\img\\{patientId}\\{examId}";

            if (!Directory.Exists(folderDest))
            {
                Directory.CreateDirectory(folderDest);
            }

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

        private void generateSQL()
        {
            string sqlContent = @"CALL CSVWRITE('C:/WimDesktopDB/migration/data/config.csv', 'SELECT 1 as ID, ''en-US'' AS LANGUAGE, ''C:\IRay\IRayIntraoral_x86\work_dir'' AS SENSOR_PATH, ''C:\WimDesktopDB\img'' AS EXAM_PATH, ''PLUTO0002X'' AS SENSOR_MODEL, 0 AS ACQUIRE_MODE, DRAWING_COLOR, DRAWING_SIZE, TEXT_COLOR, TEXT_SIZE, RULER_COLOR, 0 AS FILTER_BRIGHTNESS, 0 AS FILTER_CONTRAST, 0 AS FILTER_REVEAL, 0 AS FILTER_SMART_SHARPEN FROM SETTINGS'); CALL CSVWRITE('C:/WimDesktopDB/migration/data/patient.csv', 'SELECT ID, NAME, BIRTH_DATE, PHONE, REFERRAL AS RECOMMENDATION, NOTES AS OBSERVATION, CREATED_AT FROM PATIENT'); CALL CSVWRITE('C:/WimDesktopDB/migration/data/exam.csv', 'SELECT XRAY_EXAM.ID, MEDICAL_RECORD.PATIENT_ID AS PATIENT_ID, XRAY_EXAM_TEMPLATE_ID AS TEMPLATE_ID, NAME AS SESSION_NAME, XRAY_EXAM.CREATED_AT FROM XRAY_EXAM INNER JOIN TREATMENT ON TREATMENT.ID = XRAY_EXAM.TREATMENT_ID INNER JOIN MEDICAL_RECORD ON TREATMENT.MEDICAL_RECORD_ID = MEDICAL_RECORD.ID'); CALL CSVWRITE('C:/WimDesktopDB/migration/data/exam_image.csv', 'SELECT ID, XRAY_EXAM_ID AS EXAM_ID, XRAY_EXAM_REGION_ID AS TEMPLATE_FRAME_ID, ORIGINAL_FILE AS FILE, CASE WHEN NOTES IS NULL THEN '''' ELSE NOTES END AS NOTES, COALESCE(CREATED_AT, ''1990-01-01 00:00:00'') AS CREATED_AT FROM XRAY_EXAM_PICTURE');";

            File.WriteAllText(Path.Combine(migrationPath, @"SQLGenerateCSV.sql"), sqlContent);
        }
    }
}
