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
            ConfigModel config = configRepository.getAllConfig();

            configView.imagePath = config.examPath;
            configView.sensorPath = config.sensorPath;
        }

        private void saveConfigs(object sender, EventArgs e)
        {
            try
            {
                ConfigModel config = new ConfigModel
                {
                    examPath = configView.imagePath,
                    sensorPath = configView.sensorPath,
                };
                MessageBox.Show(configRepository.save(config));
                (sender as ConfigView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
