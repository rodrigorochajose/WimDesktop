using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Linq;
namespace DMMDigital._Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        Context context = new Context();

        public string save()
        {
            try
            {
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
