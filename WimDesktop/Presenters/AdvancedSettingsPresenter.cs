using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;

namespace WimDesktop.Presenters
{
    public class AdvancedSettingsPresenter
    {
        public IAdvancedSettingsView view { get; }

        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public AdvancedSettingsPresenter(IAdvancedSettingsView view)
        {
            this.view = view;
            view.eventUpdatePatientFiles += updatePatientFiles;
            view.eventUpdateWaterMark += updateWaterMark;
        }

        private void updatePatientFiles(object sender, EventArgs e)
        {
            try
            {
                string[] patientFolders = Directory.GetDirectories(view.examPath);

                foreach (string folder in patientFolders)
                {
                    string patientFilePath = Path.Combine(folder, "patient.txt");

                    Match match = Regex.Match(patientFilePath, @"\\(\d+)\\patient.txt");

                    PatientModel patient = patientRepository.getPatientById(int.Parse(match.Groups[1].Value));

                    if (patient != null)
                    {
                        File.WriteAllText(patientFilePath, JsonSerializer.Serialize(patient));
                    }
                }

                MessageBox.Show("Atualizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateWaterMark(object sender, EventArgs e)
        {
            settingsRepository.updateWaterMark(view.waterMark);
        }
    }
}
