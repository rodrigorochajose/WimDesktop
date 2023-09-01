using DMMDigital.Modelos;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DMMDigital.Interface
{
    public interface ITemplateLayoutRepository
    {
        string add(int templateId, IList<Frame> framesList);

        List<TemplateLayoutModel> getAllTemplateLayout();
    }
}
