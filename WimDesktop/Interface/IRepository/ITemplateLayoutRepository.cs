using WimDesktop.Components;
using WimDesktop.Models;
using System.Collections.Generic;

namespace WimDesktop.Interface.IRepository
{
    public interface ITemplateFrameRepository
    {
        void addTemplateFrame(int templateId, List<Frame> frames);

        List<TemplateFrameModel> getAllTemplateFrame();

        List<TemplateFrameModel> getTemplateFrame(int templateId);
    }
}
