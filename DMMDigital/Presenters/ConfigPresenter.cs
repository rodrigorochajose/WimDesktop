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
            configView.saveImagePath += saveImagePath;
            configView.loadImagePath += loadImagePath;

            (configView as Form).ShowDialog();
        }

        private void loadImagePath(object sender, EventArgs e)
        {
            configView.imagePath = configRepository.getAllConfig().caminho_radiografia;
        }

        private void saveImagePath(object sender, EventArgs e)
        {
            try
            {
                ConfigModel selectedConfig = configRepository.getAllConfig();
                selectedConfig.caminho_radiografia = configView.imagePath;
                MessageBox.Show(configRepository.edit(selectedConfig));
                (sender as ConfigView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
