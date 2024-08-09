using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Properties;
using System;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class ConfigRepository : IConfigRepository
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

        public ConfigModel getAllConfig()
        {
            try
            {
                return context.config.First();
            }
            catch
            {
                return new ConfigModel();
            }
        }

        public string getSensorPath()
        {
            return context.config.First().sensorPath;
        }

        public string getExamPath()
        {
            return context.config.First().examPath;
        }

        public float[] getFiltersValues()
        {
            ConfigModel config = context.config.First();
            return new float[] { config.brightness, config.contrast, config.reveal, config.smartSharpen };
        }

        public string getLanguage()
        {
            return context.config.First().language;
        }
    }
}
