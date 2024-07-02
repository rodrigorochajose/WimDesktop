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

            view.sensorPath = currentConfig.sensorPath;
            view.imagePath = currentConfig.examPath;
            view.drawingSize = currentConfig.drawingSize;
            view.drawingColor = currentConfig.drawingColor;
            view.textSize = currentConfig.textSize;
            view.textColor = currentConfig.textColor;
            view.rulerColor = currentConfig.rulerColor;
            view.gamma = currentConfig.gamma;
            view.edge = currentConfig.edge;
            view.noise = currentConfig.noise;
        }

        private void saveConfigs(object sender, EventArgs e)
        {
            try
            {
                currentConfig.sensorPath = view.sensorPath;
                currentConfig.examPath = view.imagePath;
                currentConfig.drawingColor = view.drawingColor;
                currentConfig.drawingSize = view.drawingSize;
                currentConfig.textColor = view.textColor;
                currentConfig.textSize = view.textSize;
                currentConfig.rulerColor = view.rulerColor;
                currentConfig.gamma = view.gamma;
                currentConfig.edge = view.edge;
                currentConfig.noise = view.noise;
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
