using DMMDigital.Modelos;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface ITemplateRepository
    {
        int add(TemplateModel template);
        string edit(TemplateModel template);
        List<TemplateModel> getAllTemplates();
    }
}
