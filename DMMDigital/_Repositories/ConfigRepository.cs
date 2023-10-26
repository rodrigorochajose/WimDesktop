using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        Context<ConfigModel> context = new Context<ConfigModel>();

        public string add(ConfigModel config)
        {
            throw new NotImplementedException();
        }

        public string edit(ConfigModel config)
        {
            Console.WriteLine(config);
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
            return context.tabela.First();
        }

        public string getExamPath()
        {
            return context.tabela.First().examPath.ToString();
        }
    }
}
