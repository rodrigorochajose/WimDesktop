using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
namespace DMMDigital._Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        Context context = new Context();

        public string save(ConfigModel config)
        {
            try
            {
                context.config.AddOrUpdate(config);
                context.SaveChanges();
                return "Configuração Salva !";
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

        public string getExamPath()
        {
            return context.config.First().examPath.ToString();
        }
    }
}
