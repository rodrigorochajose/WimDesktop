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
using System.IO.Compression;


namespace DMMDigital.Views
{
    public partial class MigrationDatabaseView : Form
    {
        private string warningMessage = "";
        private readonly string software = "";
        private readonly string wimMigrationPath = @"C:\WimDesktopDB\migration\tools\";
        private readonly string dataPath = "";

        private List<PatientModel> patients = new List<PatientModel>();
        private List<ExamModel> exams = new List<ExamModel>();
        private List<ExamImageModel> examImages = new List<ExamImageModel>();
        private List<ConfigModel> configs = new List<ConfigModel>();

        public MigrationDatabaseView(string software, string path)
        {
            InitializeComponent();

            label.Text = Resources.messageGettingData;

            adjustUI();

            dataPath = path;
            this.software = software;

            if (software == "WIM")
            {
                getData_WIM();
            }
            else
            {
                generateCdrModels();
            }

            startProgressBar();
        }

        private void adjustUI()
        {
            label.Left = (Width - label.Width) / 2;
        }

        private void generateSQLFile_WIM()
        {
            StringBuilder sb = new StringBuilder();

            string migrationPath = "C:/WimDesktopDB/migration/data";

            if (!Directory.Exists(migrationPath))
            {
                Directory.CreateDirectory(migrationPath);
            }

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "config.csv").Replace("\\", "/")}', " +
            "'SELECT 1 as ID, ''pt-BR'' AS LANGUAGE, ''C:\\IRay\\IRayIntraoral_x86\\work_dir'' AS SENSOR_PATH, " +
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

            File.WriteAllText(Path.Combine(wimMigrationPath, @"SQLGenerateCSV.sql"), sb.ToString());
        }

        private void getData_WIM()
        {
            generateSQLFile_WIM();

            unzipFolders();

            string javaPath = Path.Combine(wimMigrationPath, @"jdk-21.0.4\bin\java.exe");
            string h2Path = Path.Combine(wimMigrationPath, @"h2\bin\h2-1.4.200.jar");
            string dbPath = $@"jdbc:h2:{dataPath}\db\wimdb";
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

            generateModels_WIM();
        }

        private void unzipFolders()
        {
            string jdkFolder = Path.Combine(wimMigrationPath, @"jdk-21_windows-x64_bin.zip");
            string h2Folder = Path.Combine(wimMigrationPath, @"h2-2019-10-14.zip");

            if (File.Exists(jdkFolder))
            {
                ZipFile.ExtractToDirectory(jdkFolder, wimMigrationPath);
            }

            if (File.Exists(h2Folder))
            {
                ZipFile.ExtractToDirectory(h2Folder, wimMigrationPath);
            }

        }

        private void generateModels_WIM()
        {
            configs = generateModel<ConfigModel, ConfigModelMap>(@"C:\WIMDesktopDB\migration\data\config.csv");
            configs[0].drawingColor = convertHexToARGB(configs[0].drawingColor);
            configs[0].textColor = convertHexToARGB(configs[0].textColor);
            configs[0].rulerColor = convertHexToARGB(configs[0].rulerColor);

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
            using (SqlConnection connection = new SqlConnection($@"Server={Environment.MachineName}\CDRDICOM;Database=CDRData;Trusted_Connection=True;"))
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
                    MessageBox.Show($"{Resources.messageErrorConnectingDatabase} \n {ex.Message}");
                }
            }
        }

        public List<PatientModel> getPatients(SqlConnection connection)
        {
            string query = "SELECT PatientNumber as ID, (NameFirst + ' - ' + NameLast) as NAME, ISNULL(BirthDate, '1899-12-30') as BIRTHDATE, '' as PHONE, '' as RECOMMENDATION, ISNULL(Comments, '') as OBSERVATION, EnteredDate as CREATED_AT from Patient";

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
            string query = "SELECT SeriesNumber as ID, Study.PatientNumber as PATIENT_ID, 0 as TEMPLATE_ID, '' as SESSION_NAME, SeriesDate as CREATED_AT from Series INNER JOIN Study ON Series.StudyNumber = Study.StudyNumber WHERE Series.Modality = 'IO'";

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
            string query = "SELECT ImageNumber as ID, Series.SeriesNumber as EXAM_ID, ImageNumberDICOM as TEMPLATE_FRAME_ID, ImageFileName as 'FILE', '' as NOTES, Image.EnteredDate as CREATED_AT FROM Image INNER JOIN Series ON Image.SeriesNumber = Series.SeriesNumber WHERE ImageNumberDICOM IS NOT NULL AND ImageFileName LIKE '%\\IO%' AND LEN(SUBSTRING(ImageFileName, CHARINDEX('\\IO', ImageFileName), LEN(ImageFileName))) = LEN('\\IO000000')";

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
                            templateFrameId = int.Parse((string)reader["TEMPLATE_FRAME_ID"]),
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
                    MessageBox.Show(Resources.messageMigrationSuccess + warningMessage);

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

            IPatientRepository patientRepository = new PatientRepository();
            IExamRepository examRepository = new ExamRepository();
            IExamImageRepository examImageRepository = new ExamImageRepository();

            if (software == "WIM")
            {
                await importData_WIM(progress, processedPatients, patientRepository, examRepository, examImageRepository);
            }
            else
            {
                await importData_CDR(progress, processedPatients, patientRepository, examRepository, examImageRepository);
            }
        }

        private async Task importData_WIM(IProgress<int> progress, int processedPatients, IPatientRepository patientRepository, IExamRepository examRepository, IExamImageRepository examImageRepository)
        {
            int totalPatients = patients.Count;

            IConfigRepository configRepository = new ConfigRepository();
            configRepository.importConfig(configs[0]);

            foreach (PatientModel patient in patients)
            {
                int patientOldId = patient.id;

                List<ExamModel> patientExams = exams.Where(e => e.patientId == patient.id).ToList();

                patientRepository.importPatient(patient);

                if (patientExams.Any())
                {
                    foreach (ExamModel patientExam in patientExams)
                    {
                        int examOldId = patientExam.id;
                        patientExam.patientId = patient.id;

                        List<ExamImageModel> patientExamImages = examImages.Where(ei => ei.examId == patientExam.id && File.Exists($@"{dataPath}\imgs\{patientOldId}\{examOldId}\{ei.file}")).ToList();

                        examRepository.addExam(patientExam);

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
                            examImageRepository.importExamImages(patientExamImages);
                        }
                    }
                }
                processedPatients++;
                progress.Report((processedPatients * 100) / totalPatients);
            }
        }

        private async Task importData_CDR(IProgress<int> progress, int processedPatients, IPatientRepository patientRepository, IExamRepository examRepository, IExamImageRepository examImageRepository)
        {
            int examsNotImported = 0;
            int totalPatients = patients.Count;

            foreach (PatientModel patient in patients)
            {
                int patientOldId = patient.id;

                List<ExamModel> patientExams = exams.Where(e => e.patientId == patient.id).ToList();

                patientRepository.importPatient(patient);

                if (patientExams.Any())
                {
                    foreach (ExamModel patientExam in patientExams)
                    {
                        int examOldId = patientExam.id;
                        patientExam.patientId = patient.id;

                        List<ExamImageModel> patientExamImages = examImages.Where(ei => ei.examId == patientExam.id && File.Exists(Path.Combine(dataPath, ei.file + ".jpeg"))).ToList();

                        int frames = patientExamImages.Count();

                        if (frames > 50)
                        {
                            examsNotImported++;
                            generateMigrationLog(frames, examOldId, patientExamImages.First().file);
                            continue;
                        }

                        patientExam.templateId = frames < 6 ? 13 : frames < 16 ? 14 : frames < 26 ? 15 : 16;

                        examRepository.addExam(patientExam);

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
                            await importImages_CDR(patientExamImages, patient.id, patientExam.id);
                            getTemplateFrameId(patientExamImages, patientExam.templateId);
                            examImageRepository.importExamImages(patientExamImages);
                        }
                    }
                }
                processedPatients++;
                progress.Report((processedPatients * 100) / totalPatients);

                if (examsNotImported > 0)
                {
                    warningMessage = $"\nNão foi possível importar {examsNotImported} exames por exceder o limite de frames suportado.";
                }
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

        private async Task importImages_CDR(List<ExamImageModel> patientExamImages, int patientId, int examId)
        {
            string folderDest = $"C:\\WimDesktopDB\\img\\{patientId}\\{examId}";

            if (!Directory.Exists(folderDest))
            {
                Directory.CreateDirectory(folderDest);
            }

            int imageCounter = 1;

            foreach (ExamImageModel examImage in patientExamImages)
            {
                string originFile = Path.Combine(dataPath, examImage.file + ".jpeg");

                examImage.templateFrameId = imageCounter;
                examImage.file = $"{imageCounter}_original.png";

                string dest = Path.Combine(folderDest, examImage.file);

                await Task.Run(() => File.Copy(originFile, dest, overwrite: true));

                imageCounter++;
            }
        }

        private void getTemplateFrameId(List<ExamImageModel> examImages, int templateId)
        {
            ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

            List<TemplateFrameModel> templateFrames = templateFrameRepository.getTemplateFrame(templateId);

            foreach (ExamImageModel examImage in examImages)
            {
                examImage.templateFrameId = templateFrames.First(tf => tf.order == examImage.templateFrameId).id;
            }
        }

        private void generateMigrationLog(int frames, int examOldId, string file)
        {
            using (StreamWriter writer = new StreamWriter("C:/WimDesktopDB/migration/migration_log.txt", append: true))
            {
                writer.WriteLine($"ID do exame no CDR: {examOldId}");
                writer.WriteLine($"Quantidade de frames: {frames}");
                writer.WriteLine($"Caminho do arquivo: {file}\n\n\n");
            }
        }
    }
}
