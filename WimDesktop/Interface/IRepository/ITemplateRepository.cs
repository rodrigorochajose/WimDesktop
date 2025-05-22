using WimDesktop.Models;
using System.Collections.Generic;

namespace WimDesktop.Interface.IRepository
{
    public interface ITemplateRepository
    {
        void addTemplate(TemplateModel template);
        void delete(int templateId);
        List<TemplateModel> getAllTemplates();
        int getLastTemplateId();
        int getTemplateIdByName(string templateName);
        string getTemplateNameById(int templateId);
    }
}
