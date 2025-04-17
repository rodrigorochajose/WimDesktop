using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Properties;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class SettingsPresenter
    {
        public SettingsView view { get; }

        private SettingsModel currentSettings;
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();
        private readonly ISensorRepository sensorRepository = new SensorRepository();

        private readonly List<string> acquireModes = new List<string>
        {
           Resources.nativeAquireMode, "TWAIN"
        };

        public SettingsPresenter(SettingsView settingsView) 
        {
            view = settingsView;
            settingsView.saveSettings += saveSettings;
            settingsView.loadSettings += loadSettings;
        }

        private void loadSettings(object sender, EventArgs e)
        {
            currentSettings = settingsRepository.getAllSettings();

            view.setComboBoxSensorModel(sensorRepository.getAllSensors());
            view.setAcquireMode();
            view.setLanguages();

            view.language = currentSettings.language;
            view.sensorPath = currentSettings.sensorPath;
            view.examPath = currentSettings.examPath;
            view.sensorModel = currentSettings.sensorModel;
            view.acquireMode = acquireModes[currentSettings.acquireMode];
            view.drawingSize = currentSettings.drawingSize;
            view.drawingColor = currentSettings.drawingColor;
            view.textSize = currentSettings.textSize;
            view.textColor = currentSettings.textColor;
            view.rulerColor = currentSettings.rulerColor;
            view.waterMark = currentSettings.waterMark;
            view.brightness = currentSettings.brightness;
            view.contrast = currentSettings.contrast;
            view.reveal = currentSettings.reveal;
            view.smartSharpen = currentSettings.smartSharpen;
        }

        private void saveSettings(object sender, EventArgs e)
        {
            try
            {
                currentSettings.language = view.language;
                currentSettings.sensorPath = view.sensorPath;
                currentSettings.examPath = view.examPath;
                currentSettings.sensorModel = view.sensorModel;
                currentSettings.acquireMode = acquireModes.IndexOf(view.acquireMode);
                currentSettings.drawingColor = view.drawingColor;
                currentSettings.drawingSize = view.drawingSize;
                currentSettings.textColor = view.textColor;
                currentSettings.textSize = view.textSize;
                currentSettings.rulerColor = view.rulerColor;
                currentSettings.waterMark = view.waterMark;
                currentSettings.brightness = view.brightness;
                currentSettings.contrast = view.contrast;
                currentSettings.reveal = view.reveal;
                currentSettings.smartSharpen = view.smartSharpen;
                MessageBox.Show(settingsRepository.save());
                (sender as SettingsView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
