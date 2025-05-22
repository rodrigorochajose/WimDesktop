using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using WimDesktop.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WimDesktop._Repositories
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

        public int getTemplateIdByName(string templateName)
        {
            int id = 0;
            try
            {
                if (templateName == "ENDO HORIZONTAL (15)")
                {
                    templateName = "HORIZONTAL ENDO";
                }
                id = context.template.Single(t => t.name == templateName).id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return id;
        }

        public string getTemplateNameById(int templateId)
        {
            return context.template.Single(t => t.id == templateId).name;
        }
    }
}
