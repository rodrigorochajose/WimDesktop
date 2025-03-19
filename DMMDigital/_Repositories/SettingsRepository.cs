using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Properties;
using System;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly Context context = new Context();

        public string save()
        {
            try
            {
                context.SaveChanges();
                return Resources.messageConfigSucess;
            } 
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SettingsModel getAllSettings()
        {
            try
            {
                return context.settings.First();
            }
            catch
            {
                return new SettingsModel();
            }
        }

        public string getSensorPath()
        {
            return context.settings.First().sensorPath;
        }

        public string getSensorModel()
        {
            return context.settings.First().sensorModel;
        }

        public int getAcquireMode()
        {
            return context.settings.First().acquireMode;
        }

        public string getExamPath()
        {
            return context.settings.First().examPath;
        }

        public float[] getFiltersValues()
        {
            SettingsModel settings = context.settings.First();
            return new float[] { settings.brightness, settings.contrast, settings.reveal, settings.smartSharpen };
        }

        public string getLanguage()
        {
            return context.settings.First().language;
        }

        public void importSettings(SettingsModel settings)
        {
            try
            {
                SettingsModel currentSettings = context.settings.First();
                context.Entry(currentSettings).CurrentValues.SetValues(settings);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void saveExportPath(string path)
        {
            SettingsModel currentSettings = context.settings.First();

            currentSettings.exportPath = path;

            context.SaveChanges();
        }

        public string getExportPath()
        {
            return context.settings.First().exportPath;
        }
    }
}
