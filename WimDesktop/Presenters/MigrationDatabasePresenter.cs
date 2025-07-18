using CsvHelper.Configuration;
using CsvHelper;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class MigrationDatabasePresenter
    {
        private readonly string wimMigrationPath = @"C:\WimDesktopDB\migration\tools\";
        private readonly string dataPath = "";

        private readonly IMigrationDatabaseView migrationDatabaseView;
        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public MigrationDatabasePresenter(IMigrationDatabaseView view, string path)
        {
            migrationDatabaseView = view;

            dataPath = path;

            view.eventImportPatient += importPatient;
            view.eventImportExam += importExam;
            view.eventImportExamImages += importExamImages;
            view.eventImportSettings += importSettings;
            view.eventGetDataToImport += getData;

            (view as Form).ShowDialog();
        }

        private void getData(object sender, EventArgs e)
        {
            if (migrationDatabaseView.software == "WIM")
            {
                getData_WIM();
            }
            else
            {
                generateCdrModels();
            }
        }

        private void generateCdrModels()
        {
            using (SqlConnection connection = new SqlConnection($@"Server={Environment.MachineName}\CDRDICOM;Database=CDRData;Trusted_Connection=True;"))
            {
                try
                {
                    connection.Open();

                    getPatients(connection);
                    getExams(connection);
                    getExamImages(connection);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"{Resources.messageErrorConnectingDatabase} \n {ex.Message}");
                }
            }
        }

        public void getPatients(SqlConnection connection)
        {
            string query = "SELECT PatientNumber as ID, (NameFirst + ' - ' + NameLast) as NAME, ISNULL(BirthDate, '1899-12-30') as BIRTHDATE, '' as PHONE, '' as RECOMMENDATION, ISNULL(Comments, '') as OBSERVATION, EnteredDate as CREATED_AT from Patient";

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

                        migrationDatabaseView.patients.Add(patient);
                    }
                }
            }
        }

        public void getExams(SqlConnection connection)
        {
            string query = "SELECT StudyNumber as ID, PatientNumber as PATIENT_ID, 0 as TEMPLATE_ID, '' as SESSION_NAME, StudyDate as CREATED_AT, ModifiedDate as UPDATED_AT from Study";

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
                            createdAt = (DateTime)reader["CREATED_AT"],
                            updatedAt = (DateTime)reader["UPDATED_AT"]
                        };

                        migrationDatabaseView.exams.Add(exam);
                    }
                }
            }
        }

        public void getExamImages(SqlConnection connection)
        {
            string query = "SELECT ImageNumber as ID, Study.StudyNumber as EXAM_ID, ImageNumberDICOM as TEMPLATE_FRAME_ID, ImageNumberDICOM as ORDINATION, ImageUID as IMGUID, ImageFileName as 'FILE', '' as NOTES, Image.EnteredDate as CREATED_AT FROM Image INNER JOIN Series ON Image.SeriesNumber = Series.SeriesNumber INNER JOIN Study ON Series.StudyNumber = Study.StudyNumber WHERE ImageNumberDICOM IS NOT NULL";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ExamImageCDR examImage = new ExamImageCDR
                        {
                            uid = (string)reader["IMGUID"],
                            id = (int)reader["ID"],
                            examId = (int)reader["EXAM_ID"],
                            order = int.Parse((string)reader["ORDINATION"]),
                            templateFrameId = int.Parse((string)reader["TEMPLATE_FRAME_ID"]),
                            file = (string)reader["FILE"],
                            notes = (string)reader["NOTES"],
                            createdAt = (DateTime)reader["CREATED_AT"]
                        };

                        migrationDatabaseView.examImagesCDR.Add(examImage);
                    }
                }
            }
        }

        private void getData_WIM()
        {
            checkAndDeleteOldFiles();

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
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }

            File.Delete(Path.Combine(wimMigrationPath, @"SQLGenerateCSV.sql"));

            generateModels_WIM();
        }

        private void checkAndDeleteOldFiles()
        {
            string migrationDataDir = @"C:\WIMDesktopDB\migration\data";

            if (Directory.Exists(migrationDataDir))
            {
                Directory.Delete(migrationDataDir, true);
            }

            string scriptPath = Path.Combine(wimMigrationPath, @"SQLGenerateCSV.sql");

            if (File.Exists(scriptPath))
            {
                File.Delete(scriptPath);
            }
        }

        private void generateSQLFile_WIM()
        {
            StringBuilder sb = new StringBuilder();

            string migrationPath = "C:/WimDesktopDB/migration/data";

            if (Directory.Exists(migrationPath))
            {
                Directory.Delete(migrationPath, true);
            }

            Directory.CreateDirectory(migrationPath);
            
            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "settings.csv").Replace("\\", "/")}', " +
                "'SELECT 1 as ID, ''pt-BR'' AS LANGUAGE, ''C:\\IRay\\IRayIntraoral_x86\\work_dir'' AS SENSOR_PATH, " +
                "''C:\\WimDesktopDB\\img'' AS EXAM_PATH, ''PLUTO0002X'' AS SENSOR_MODEL, 0 AS ACQUIRE_MODE, " +
                "DRAWING_COLOR, DRAWING_SIZE, TEXT_COLOR, TEXT_SIZE, RULER_COLOR, 1 AS WATERMARK, 0 AS FILTER_BRIGHTNESS, " +
                "0 AS FILTER_CONTRAST, 0 AS FILTER_REVEAL, 0 AS FILTER_SMART_SHARPEN FROM SETTINGS', " +
                "'charset=UTF-8 fieldSeparator=,');");

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "patient.csv").Replace("\\", "/")}', " +
                "'SELECT ID, NAME, BIRTH_DATE, PHONE, REFERRAL AS RECOMMENDATION, NOTES AS OBSERVATION, CREATED_AT FROM PATIENT', " +
                "'charset=UTF-8 fieldSeparator=,');");

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "exam.csv").Replace("\\", "/")}', " +
                "'SELECT XRAY_EXAM.ID, MEDICAL_RECORD.PATIENT_ID AS PATIENT_ID, XRAY_EXAM_TEMPLATE_ID AS TEMPLATE_ID, " +
                "NAME AS SESSION_NAME, XRAY_EXAM.CREATED_AT, XRAY_EXAM.CREATED_AT AS UPDATED_AT FROM XRAY_EXAM INNER JOIN TREATMENT ON TREATMENT.ID = XRAY_EXAM.TREATMENT_ID " +
                "INNER JOIN MEDICAL_RECORD ON TREATMENT.MEDICAL_RECORD_ID = MEDICAL_RECORD.ID', " +
                "'charset=UTF-8 fieldSeparator=,');");

            sb.AppendLine($"CALL CSVWRITE('{Path.Combine(migrationPath, "exam_image.csv").Replace("\\", "/")}', " +
                "'SELECT ID, XRAY_EXAM_ID AS EXAM_ID, XRAY_EXAM_REGION_ID AS TEMPLATE_FRAME_ID, ORIGINAL_FILE AS FILE, " +
                "CASE WHEN NOTES IS NULL THEN '''' ELSE NOTES END AS NOTES, COALESCE(CREATED_AT, ''1990-01-01 00:00:00'') AS CREATED_AT " +
                "FROM XRAY_EXAM_PICTURE', " +
                "'charset=UTF-8 fieldSeparator=,');");


            File.WriteAllText(Path.Combine(wimMigrationPath, @"SQLGenerateCSV.sql"), sb.ToString());
        }

        private void unzipFolders()
        {
            if (Directory.Exists(Path.Combine(wimMigrationPath, "jdk-21.0.4")) && Directory.Exists(Path.Combine(wimMigrationPath, "h2")))
            {
                return;
            }

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
            string migrationDataPath = @"C:\WIMDesktopDB\migration\data";

            migrationDatabaseView.settingsToImport = generateModel<SettingsModel, SettingsModelMap>(Path.Combine(migrationDataPath, "settings.csv")).First();

            migrationDatabaseView.settingsToImport.drawingColor = convertHexToARGB(migrationDatabaseView.settingsToImport.drawingColor);
            migrationDatabaseView.settingsToImport.textColor = convertHexToARGB(migrationDatabaseView.settingsToImport.textColor);
            migrationDatabaseView.settingsToImport.rulerColor = convertHexToARGB(migrationDatabaseView.settingsToImport.rulerColor);

            migrationDatabaseView.patients = generateModel<PatientModel, PatientModelMap>(Path.Combine(migrationDataPath, "patient.csv"));
            migrationDatabaseView.exams = generateModel<ExamModel, ExamModelMap>(Path.Combine(migrationDataPath, "exam.csv"));
            migrationDatabaseView.examImages = generateModel<ExamImageModel, ExamImageModelMap>(Path.Combine(migrationDataPath, "exam_image.csv"));
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

        private void importPatient(object sender, EventArgs e)
        {
            patientRepository.importPatient(migrationDatabaseView.patientToImport);
        }

        private void importExam(object sender, EventArgs e)
        {
            examRepository.addExam(migrationDatabaseView.examToImport);
        }

        private void importExamImages(object sender, EventArgs e)
        {
            examImageRepository.importExamImages(migrationDatabaseView.examImagesToImport);
        }

        private void importSettings(object sender, EventArgs e)
        {
            settingsRepository.importSettings(migrationDatabaseView.settingsToImport);
        }
    }
}
