using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        Contexto<TemplateModel> context = new Contexto<TemplateModel>();

        public string add(TemplateModel template)
        {
            throw new NotImplementedException();
        }

        public string edit(TemplateModel template)
        {
            throw new NotImplementedException();
        }

        public List<TemplateModel> getAllTemplates()
        {
            return context.tabela.OrderBy(template => template.id).ToList();
        }
    }
}
