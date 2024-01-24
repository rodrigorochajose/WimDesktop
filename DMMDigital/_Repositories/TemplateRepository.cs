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
            try
            {
                context.SaveChanges();
                return "Template editado com sucesso !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string delete(int templateId)
        {
            try
            {
                context.template.Remove(context.template.Single(p => p.id == templateId));
                context.SaveChanges();
                return "Template Removido com sucesso !";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<TemplateModel> getAllTemplates()
        {
            return context.template.OrderBy(template => template.id).ToList();
        }
    }
}
