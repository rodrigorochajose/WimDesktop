using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ConfigPresenter
    {
        public ConfigView view { get; }

        private ConfigModel currentConfig;
        private readonly IConfigRepository configRepository;
        private ISensorRepository sensorRepository = new SensorRepository();
        
        public ConfigPresenter(ConfigView configView, IConfigRepository repository) 
        {
            view = configView;
            configRepository = repository;
            configView.saveConfigs += saveConfigs;
            configView.loadConfigs += loadConfigs;
        }

        private void loadConfigs(object sender, EventArgs e)
        {
            currentConfig = configRepository.getAllConfig();

            view.setComboBoxSensorModel(sensorRepository.getAllSensors());
            view.setAcquireMode();

            view.sensorPath = currentConfig.sensorPath;
            view.examPath = currentConfig.examPath;
            view.sensorModel = currentConfig.sensorModel;
            view.acquireMode = currentConfig.acquireMode;
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
                currentConfig.sensorPath = view.sensorPath;
                currentConfig.examPath = view.examPath;
                currentConfig.sensorModel = view.sensorModel;
                currentConfig.acquireMode = view.acquireMode;
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
    }
}
