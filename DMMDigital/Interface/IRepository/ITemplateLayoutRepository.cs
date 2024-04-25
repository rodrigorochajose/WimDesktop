using DMMDigital.Components;
using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface.IRepository
{
    public interface ITemplateFrameRepository
    {
        string add(int templateId, IList<Frame> framesList);

        List<TemplateFrameModel> getAllTemplateFrame();

        List<TemplateFrameModel> getTemplateFrame(int templateId);
    }
}
