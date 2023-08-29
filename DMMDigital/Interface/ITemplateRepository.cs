using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital.Interface
{
    public interface ITemplateRepository
    {
        string add(TemplateModel template);
        string edit(TemplateModel template);
        List<TemplateModel> getAllTemplates();
    }
}
