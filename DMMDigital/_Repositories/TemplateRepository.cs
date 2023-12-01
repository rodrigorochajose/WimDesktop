using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        Context context = new Context();

        public int add(TemplateModel template)
        {
            context.template.Add(template);
            context.SaveChanges();
            return template.id;
        }

        public string edit(TemplateModel template)
        {
            throw new NotImplementedException();
        }

        public List<TemplateModel> getAllTemplates()
        {
            return context.template.OrderBy(template => template.id).ToList();
        }
    }
}
