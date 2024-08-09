using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly Context context = new Context();

        public void addTemplate(TemplateModel template)
        {
            try
            {
                context.template.Add(template);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void delete(int templateId)
        {
            try
            {
                if (context.exam.Any(e => e.templateId == templateId))
                {
                    MessageBox.Show(Resources.messageTemplateCannotDelete);
                    return;
                }

                context.templateFrame.RemoveRange(context.templateFrame.Where(t => t.templateId == templateId));
                context.template.Remove(context.template.Single(p => p.id == templateId));
                context.SaveChanges();

                MessageBox.Show(Resources.messageTemplateDeleteSucess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<TemplateModel> getAllTemplates()
        {
            return context.template.OrderBy(template => template.id).ToList();
        }

        public int getLastTemplateId()
        {
            return context.template.OrderByDescending(t => t.id).First().id;
        }
    }
}
