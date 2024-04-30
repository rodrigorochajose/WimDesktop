using DMMDigital.Components;
using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface.IRepository
{
    public interface ITemplateFrameRepository
    {
        void addTemplateFrame(int templateId, List<Frame> frames);

        List<TemplateFrameModel> getAllTemplateFrame();

        List<TemplateFrameModel> getTemplateFrame(int templateId);
    }
}
