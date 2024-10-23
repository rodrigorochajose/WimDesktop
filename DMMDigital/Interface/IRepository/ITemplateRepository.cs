using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface.IRepository
{
    public interface ITemplateRepository
    {
        void addTemplate(TemplateModel template);
        void delete(int templateId);
        List<TemplateModel> getAllTemplates();
        int getLastTemplateId();
        int getTemplateIdByName(string templateName);
    }
}
