using DMMDigital.Forms;
using DMMDigital.Interface;
using DMMDigital.Modelos;
using DMMDigital.Views;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ConfigPresenter
    {
        private IConfigView view;
        private IConfigRepository repository;
        
        public ConfigPresenter(IConfigView view, IConfigRepository repository) {
            this.view = view;
            this.repository = repository;
            this.view.saveImagePath += saveImagePath;
            this.view.loadImagePath += loadImagePath;

            (this.view as Form).ShowDialog();
        }

        private void loadImagePath(object sender, EventArgs e)
        {
            view.imagePath = repository.getAllConfig().caminho_radiografia;
        }

        private void saveImagePath(object sender, EventArgs e)
        {
            try
            {
                ConfigModel selectedConfig = repository.getAllConfig();
                selectedConfig.caminho_radiografia = this.view.imagePath;
                MessageBox.Show(repository.edit(selectedConfig));
                (sender as ConfigView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
