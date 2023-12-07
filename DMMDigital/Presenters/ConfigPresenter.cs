using DMMDigital.Forms;
using DMMDigital.Interface;
using DMMDigital.Modelos;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ConfigPresenter
    {
        private ConfigModel currentConfig;
        private IConfigView configView;
        private IConfigRepository configRepository;
        
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

            configView.imagePath = currentConfig.examPath;
            configView.sensorPath = currentConfig.sensorPath;
        }

        private void saveConfigs(object sender, EventArgs e)
        {
            try
            {
                currentConfig.examPath = configView.imagePath;
                currentConfig.sensorPath = configView.sensorPath;
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
