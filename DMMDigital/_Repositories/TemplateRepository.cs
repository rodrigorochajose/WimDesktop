using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly Context context = new Context();

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
