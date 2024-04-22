using DMMDigital.Interface;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ConfigPresenter
    {
        private ConfigModel currentConfig;
        private readonly IConfigView configView;
        private readonly IConfigRepository configRepository;
        
        public ConfigPresenter(IConfigView view, IConfigRepository repository) {
            configView = view;
            configRepository = repository;
            configView.saveConfigs += saveConfigs;
            configView.loadConfigs += loadConfigs;

            (configView as Form).ShowDialog();
        }

        private void loadConfigs(object sender, EventArgs e)
        {
            currentConfig = configRepository.getAllConfig();

            configView.sensorPath = currentConfig.sensorPath;
            configView.imagePath = currentConfig.examPath;
            configView.drawingSize = currentConfig.drawingSize;
            configView.drawingColor = currentConfig.drawingColor;
            configView.textSize = currentConfig.textSize;
            configView.textColor = currentConfig.textColor;
            configView.rulerColor = currentConfig.rulerColor;
        }

        private void saveConfigs(object sender, EventArgs e)
        {
            try
            {
                currentConfig.sensorPath = configView.sensorPath;
                currentConfig.examPath = configView.imagePath;
                currentConfig.drawingColor = configView.drawingColor;
                currentConfig.drawingSize = configView.drawingSize;
                currentConfig.textColor = configView.textColor;
                currentConfig.textSize = configView.textSize;
                currentConfig.rulerColor = configView.rulerColor;
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
