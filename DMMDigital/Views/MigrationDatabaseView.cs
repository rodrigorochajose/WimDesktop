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
using System.Data.SqlClient;
using System.Text;


namespace DMMDigital.Views
{
    public partial class MigrationDatabaseView : Form
    {
        private string software = "";

        private string wimMigrationPath = @"C:\WimDesktopDB\migration\tools\";


        private List<PatientModel> patients = new List<PatientModel>();
        private List<ExamModel> exams = new List<ExamModel>();
        private List<ExamImageModel> examImages = new List<ExamImageModel>();

        public MigrationDatabaseView(string software)
        {
            InitializeComponent();

            label.Text = Resources.messageGettingData;

            adjust();

            this.software = software;

            if (software == "WIM")
            {
                getDataFromCSV();
            }
            else
            {
                MessageBox.Show("ainda em implementação...");
                return;
                //generateCdrModels();
            }

            // importData
            startProgressBar();
        }

        private void adjust()
        {
            label.Left = (Width - label.Width) / 2;
        }

        private void createSQLToGetData()
        {
            StringBuilder sb = new StringBuilder();

            string migrationPath = "C:/WimDesktopDB/migration/data";

            if (!Directory.Exists(migrationPath))
            {
                Directory.CreateDirectory(migrationPath);
            }

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "config.csv").Replace("\\", "/")}', " +
            "'SELECT 1 as ID, ''en-US'' AS LANGUAGE, ''C:\\IRay\\IRayIntraoral_x86\\work_dir'' AS SENSOR_PATH, " +
            "''C:\\WimDesktopDB\\img'' AS EXAM_PATH, ''PLUTO0002X'' AS SENSOR_MODEL, 0 AS ACQUIRE_MODE, " +
            "DRAWING_COLOR, DRAWING_SIZE, TEXT_COLOR, TEXT_SIZE, RULER_COLOR, 0 AS FILTER_BRIGHTNESS, " +
            "0 AS FILTER_CONTRAST, 0 AS FILTER_REVEAL, 0 AS FILTER_SMART_SHARPEN FROM SETTINGS');");

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "patient.csv").Replace("\\", "/")}', " +
                "'SELECT ID, NAME, BIRTH_DATE, PHONE, REFERRAL AS RECOMMENDATION, NOTES AS OBSERVATION, CREATED_AT FROM PATIENT');");

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "exam.csv").Replace("\\", "/")}', " +
                "'SELECT XRAY_EXAM.ID, MEDICAL_RECORD.PATIENT_ID AS PATIENT_ID, XRAY_EXAM_TEMPLATE_ID AS TEMPLATE_ID, " +
                "NAME AS SESSION_NAME, XRAY_EXAM.CREATED_AT FROM XRAY_EXAM INNER JOIN TREATMENT ON TREATMENT.ID = XRAY_EXAM.TREATMENT_ID " +
                "INNER JOIN MEDICAL_RECORD ON TREATMENT.MEDICAL_RECORD_ID = MEDICAL_RECORD.ID');");

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "exam_image.csv").Replace("\\", "/")}', " +
                "'SELECT ID, XRAY_EXAM_ID AS EXAM_ID, XRAY_EXAM_REGION_ID AS TEMPLATE_FRAME_ID, ORIGINAL_FILE AS FILE, " +
                "CASE WHEN NOTES IS NULL THEN '''' ELSE NOTES END AS NOTES, COALESCE(CREATED_AT, ''1990-01-01 00:00:00'') AS CREATED_AT " +
                "FROM XRAY_EXAM_PICTURE');");


            // string sqlContent = @"CALL CSVWRITE('C:/WimDesktopDB/migration/data/config.csv', 'SELECT 1 as ID, ''en-US'' AS LANGUAGE, ''C:\IRay\IRayIntraoral_x86\work_dir'' AS SENSOR_PATH, ''C:\WimDesktopDB\img'' AS EXAM_PATH, ''PLUTO0002X'' AS SENSOR_MODEL, 0 AS ACQUIRE_MODE, DRAWING_COLOR, DRAWING_SIZE, TEXT_COLOR, TEXT_SIZE, RULER_COLOR, 0 AS FILTER_BRIGHTNESS, 0 AS FILTER_CONTRAST, 0 AS FILTER_REVEAL, 0 AS FILTER_SMART_SHARPEN FROM SETTINGS'); CALL CSVWRITE('C:/WimDesktopDB/migration/data/patient.csv', 'SELECT ID, NAME, BIRTH_DATE, PHONE, REFERRAL AS RECOMMENDATION, NOTES AS OBSERVATION, CREATED_AT FROM PATIENT'); CALL CSVWRITE('C:/WimDesktopDB/migration/data/exam.csv', 'SELECT XRAY_EXAM.ID, MEDICAL_RECORD.PATIENT_ID AS PATIENT_ID, XRAY_EXAM_TEMPLATE_ID AS TEMPLATE_ID, NAME AS SESSION_NAME, XRAY_EXAM.CREATED_AT FROM XRAY_EXAM INNER JOIN TREATMENT ON TREATMENT.ID = XRAY_EXAM.TREATMENT_ID INNER JOIN MEDICAL_RECORD ON TREATMENT.MEDICAL_RECORD_ID = MEDICAL_RECORD.ID'); CALL CSVWRITE('C:/WimDesktopDB/migration/data/exam_image.csv', 'SELECT ID, XRAY_EXAM_ID AS EXAM_ID, XRAY_EXAM_REGION_ID AS TEMPLATE_FRAME_ID, ORIGINAL_FILE AS FILE, CASE WHEN NOTES IS NULL THEN '''' ELSE NOTES END AS NOTES, COALESCE(CREATED_AT, ''1990-01-01 00:00:00'') AS CREATED_AT FROM XRAY_EXAM_PICTURE');";

            File.WriteAllText(Path.Combine(wimMigrationPath, @"SQLGenerateCSV.sql"), sb.ToString());
        }

        private void getDataFromCSV()
        {
            createSQLToGetData();

            string javaPath = Path.Combine(wimMigrationPath, @"jdk-21_windows-x64_bin\jdk-21.0.4\bin\java.exe");
            string h2Path = Path.Combine(wimMigrationPath, @"h2-2019-10-14\h2\bin\h2-1.4.200.jar");
            string dbPath = $@"jdbc:h2:{Environment.GetEnvironmentVariable("USERPROFILE")}\.wimdesktop\db\wimdb";
            string scriptPath = Path.Combine(wimMigrationPath, @"SQLGenerateCSV.sql");

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            File.Delete(Path.Combine(wimMigrationPath, @"SQLGenerateCSV.sql"));

            generateWimModels();
        }

        private void generateWimModels()
        {
            List<ConfigModel> configs = generateModel<ConfigModel, ConfigModelMap>(@"C:\WIMDesktopDB\migration\data\config.csv");
            configs[0].drawingColor = convertHexToARGB(configs[0].drawingColor);
            configs[0].textColor = convertHexToARGB(configs[0].textColor);
            configs[0].rulerColor = convertHexToARGB(configs[0].rulerColor);

            // importar configuração 

            patients = generateModel<PatientModel, PatientModelMap>(@"C:\WIMDesktopDB\migration\data\patient.csv");
            exams = generateModel<ExamModel, ExamModelMap>(@"C:\WIMDesktopDB\migration\data\exam.csv");
            examImages = generateModel<ExamImageModel, ExamImageModelMap>(@"C:\WIMDesktopDB\migration\data\exam_image.csv");
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

        private void generateCdrModels()
        {
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-KJ85CG4\CDRDICOM;Database=CDRData;Trusted_Connection=True;"))
            {
                try
                {
                    connection.Open();

                    patients = getPatients(connection);
                    exams = getExams(connection);
                    examImages = getExamImages(connection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }
        }

        public List<PatientModel> getPatients(SqlConnection connection)
        {
            string query = "SELECT PatientNumber as ID, (NameFirst + ' ' + NameLast) as NAME, ISNULL(BirthDate, '1899-12-30') as BIRTHDATE, '' as PHONE, '' as RECOMMENDATION, ISNULL(Comments, '') as OBSERVATION, EnteredDate as CREATED_AT from Patient";

            List<PatientModel> patients = new List<PatientModel>();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PatientModel patient = new PatientModel
                        {
                            id = (int)reader["ID"],
                            name = (string)reader["NAME"],
                            birthDate = (DateTime)reader["BIRTHDATE"],
                            phone = (string)reader["PHONE"],
                            recommendation = (string)reader["RECOMMENDATION"],
                            observation = (string)reader["OBSERVATION"],
                            createdAt = (DateTime)reader["CREATED_AT"]
                        };

                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }

        public List<ExamModel> getExams(SqlConnection connection)
        {
            string query = "SELECT StudyNumber as ID, PatientNumber as PATIENT_ID, 13 as TEMPLATE_ID, '' as SESSION_NAME, EnteredDate as CREATED_AT from Study";

            List<ExamModel> exams = new List<ExamModel>();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ExamModel exam = new ExamModel
                        {
                            id = (int)reader["ID"],
                            patientId = (int)reader["PATIENT_ID"],
                            templateId = (int)reader["TEMPLATE_ID"],
                            sessionName = (string)reader["SESSION_NAME"],
                            createdAt = (DateTime)reader["CREATED_AT"]
                        };

                        exams.Add(exam);
                    }
                }
            }
            return exams;
        }

        public List<ExamImageModel> getExamImages(SqlConnection connection)
        {
            string query = "SELECT ImageNumber as ID, Series.StudyNumber as EXAM_ID, ImageNumberDICOM as FRAME_ID, ImageFileName as 'FILE', '' as NOTES, Image.EnteredDate as CREATED_AT FROM Image INNER JOIN Series ON Image.SeriesNumber = Series.SeriesNumber WHERE ImageNumberDICOM IS NOT NULL";
            List<ExamImageModel> examImages = new List<ExamImageModel>();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ExamImageModel examImage = new ExamImageModel
                        {
                            id = (int)reader["ID"],
                            examId = (int)reader["EXAM_ID"],
                            templateFrameId = int.Parse((string)reader["FRAME_ID"]),
                            file = (string)reader["FILE"],
                            notes = (string)reader["NOTES"],
                            createdAt = (DateTime)reader["CREATED_AT"]
                        };

                        examImages.Add(examImage);
                    }
                }
            }
            return examImages;
        }

        private async void startProgressBar()
        {
            var progress = new Progress<int>(value =>
            {
                progressBar.Value = value;

                if (progressBar.Value >= progressBar.Maximum)
                {
                    MessageBox.Show(Resources.messageMigrationSuccess);

                    //Directory.Delete(@"C:\WimDesktopDB\migration\data", true);

                    Close();
                }
            });

            await importDataAsync(progress);
        }

        private async Task importDataAsync(IProgress<int> progress)
        {
            label.Text = Resources.messageImportData;
            adjust();

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

                            var importExamImagesTask = Task.Run(() => examImageRepository.importExamImages(patientExamImages));

                            Task importImagesAsyncTask;

                            if (software == "WIM")
                            {
                                importImagesAsyncTask = importImagesAsync(patientOldId, patient.id, examOldId, patientExam.id);
                            }
                            else
                            {
                                List<string> files = patientExamImages.Select(p => p.file).ToList();
                                importImagesAsyncTask = importImagesCDRAsync(files, patient.id, examOldId);
                            }

                            await Task.WhenAll(importExamImagesTask, importImagesAsyncTask);
                        }
                    }
                }
                processedPatients++;
                progress.Report((processedPatients * 100) / totalPatients);
            }
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

        private async Task importImagesCDRAsync(List<string> files, int patientId, int examId)
        {
            string basePath = "C:/images";
            string folderDest = $"C:\\WimDesktopDB\\img\\{patientId}\\{examId}";


            foreach (string file in files)
            {
                string originFile = Path.Combine(basePath, file, ".jpeg");

                string destFileName = file.Substring(file.Length - 2);

                //string dest = Path.Combine(folderDest, fileName);
                //await Task.Run(() => File.Copy(file, dest, overwrite: true));
            }
        }
    }
}
