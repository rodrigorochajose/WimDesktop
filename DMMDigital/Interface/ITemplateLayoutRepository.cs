using DMMDigital.Modelos;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DMMDigital.Interface
{
    public interface ITemplateFrameRepository
    {
        string add(int templateId, IList<Frame> framesList);

        List<TemplateFrameModel> getAllTemplateFrame();

        List<TemplateFrameModel> getTemplateFrame(int templateId);
    }
}
