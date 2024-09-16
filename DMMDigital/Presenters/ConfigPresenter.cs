using CsvHelper.Configuration;
using CsvHelper;
using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Properties;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Globalization;

namespace DMMDigital.Presenters
{
    public class ConfigPresenter
    {
        public ConfigView view { get; }

        private ConfigModel currentConfig;
        private readonly IConfigRepository configRepository;
        private readonly ISensorRepository sensorRepository = new SensorRepository();

        private readonly List<string> acquireModes = new List<string>
        {
           Resources.nativeAquireMode, "TWAIN"
        };

        public ConfigPresenter(ConfigView configView, IConfigRepository repository) 
        {
            view = configView;
            configRepository = repository;
            configView.saveConfigs += saveConfigs;
            configView.loadConfigs += loadConfigs;
            configView.migrateWimDesktop += migrateWimDesktopDatabase;
            configView.migrateCDR += migrateCDRDatabase;
        }

        private void loadConfigs(object sender, EventArgs e)
        {
            currentConfig = configRepository.getAllConfig();

            view.setComboBoxSensorModel(sensorRepository.getAllSensors());
            view.setAcquireMode();
            view.setLanguages();

            view.language = currentConfig.language;
            view.sensorPath = currentConfig.sensorPath;
            view.examPath = currentConfig.examPath;
            view.sensorModel = currentConfig.sensorModel;
            view.acquireMode = acquireModes[currentConfig.acquireMode];
            view.drawingSize = currentConfig.drawingSize;
            view.drawingColor = currentConfig.drawingColor;
            view.textSize = currentConfig.textSize;
            view.textColor = currentConfig.textColor;
            view.rulerColor = currentConfig.rulerColor;
            view.brightness = currentConfig.brightness;
            view.contrast = currentConfig.contrast;
            view.reveal = currentConfig.reveal;
            view.smartSharpen = currentConfig.smartSharpen;
        }

        private void saveConfigs(object sender, EventArgs e)
        {
            try
            {
                currentConfig.language = view.language;
                currentConfig.sensorPath = view.sensorPath;
                currentConfig.examPath = view.examPath;
                currentConfig.sensorModel = view.sensorModel;
                currentConfig.acquireMode = acquireModes.IndexOf(view.acquireMode);
                currentConfig.drawingColor = view.drawingColor;
                currentConfig.drawingSize = view.drawingSize;
                currentConfig.textColor = view.textColor;
                currentConfig.textSize = view.textSize;
                currentConfig.rulerColor = view.rulerColor;
                currentConfig.brightness = view.brightness;
                currentConfig.contrast = view.contrast;
                currentConfig.reveal = view.reveal;
                currentConfig.smartSharpen = view.smartSharpen;
                MessageBox.Show(configRepository.save());
                (sender as ConfigView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void migrateWimDesktopDatabase(object sender, EventArgs e)
        {
            importData();
            //importImages();
        }

        private void migrateCDRDatabase(object sender, EventArgs e)
        {

        }

        private void importData()
        {
            string dataPath = @"C:\WIMDesktopDB\migracao";

            List<ConfigModel> configs = generateModel<ConfigModel, ConfigModelMap>(Path.Combine(dataPath, "config.csv"));
            configs[0].drawingColor = convertHexToARGB(configs[0].drawingColor);
            configs[0].textColor = convertHexToARGB(configs[0].textColor);
            configs[0].rulerColor = convertHexToARGB(configs[0].rulerColor);

            List<PatientModel> patients = generateModel<PatientModel, PatientModelMap>(Path.Combine(dataPath, "patient.csv"));
            List<ExamModel> exams = generateModel<ExamModel, ExamModelMap>(Path.Combine(dataPath, "exam.csv"));
            List<ExamImageModel> examImages = generateModel<ExamImageModel, ExamImageModelMap>(Path.Combine(dataPath, "exam_image.csv"));

            IPatientRepository patientRepository = new PatientRepository();
            IExamRepository examRepository = new ExamRepository();
            IExamImageRepository examImageRepository = new ExamImageRepository();

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

                        List<ExamImageModel> patientExamImages = examImages.Where(ei => ei.examId == patientExam.id).ToList();

                        examRepository.addExam(patientExam);

                        if (patientExamImages.Any())
                        {
                            patientExamImages.ForEach(ei => ei.examId = patientExam.id);
                            examImageRepository.importExamImages(patientExamImages);
                        }

                        importImages(patientOldId, patient.id, examOldId, patientExam.id);
                    }
                }
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

        private void importImages(int patientOldId, int patientId, int examOldId, int examId)
        {
            string patientFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), $".wimdesktop\\imgs\\{patientOldId}");

            string[] files = Directory.GetFiles(Path.Combine(patientFolder, $"{examOldId}"));

            string folderDest = $"C:\\WimDesktopDB\\img{patientId}\\{examId}";

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
                    File.Copy(file, dest, overwrite: true);
                }
            }
        }
    }
}
