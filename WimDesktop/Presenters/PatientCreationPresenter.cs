using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class PatientCreationPresenter
    {
        private IPatientCreationView view;
        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public PatientCreationPresenter(IPatientCreationView view)
        {
            this.view = view;

            view.eventAddNewPatient += addNewPatient;
        }

        private void addNewPatient(object sender, EventArgs e)
        {
            try
            {
                PatientModel newPatient = new PatientModel
                {
                    id = view.patientId,
                    name = view.patientName,
                    birthDate = view.patientBirthDate,
                    phone = view.patientPhone,
                    recommendation = view.patientRecommendation,
                    observation = view.patientObservation,
                };

                new Common.ModelDataValidation().Validate(newPatient);
                patientRepository.addPatient(newPatient);

                generatePatientFile(newPatient);
                (view as Form).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void generatePatientFile(PatientModel patient)
        {
            string patientPath = Path.Combine(settingsRepository.getExamPath(), $"{patient.id}");

            Directory.CreateDirectory(patientPath);

            string filePath = Path.Combine(patientPath, "patient.txt");

            try
            {
                string patientData = $"Nome: {patient.name}{Environment.NewLine}Criado em: {patient.createdAt:yyyy-MM-dd HH:mm:ss}";

                File.WriteAllText(filePath, patientData);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Erro ao serializar: {e.Message}\n{e.StackTrace}");
            }
        }
    }
}
