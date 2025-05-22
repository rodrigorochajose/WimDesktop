using WimDesktop.Models;
using System;
using System.Collections.Generic;

namespace WimDesktop.Interface.IView
{
    public interface ITemplateCreationSetupView
    {
        string templateName { get; set; }
        bool generateByTemplate { get; set; }
        int rows { get; set; }
        int columns { get; set; }
        int orientation { get; set; }
        List<TemplateFrameModel> templateFrames { get; set; }
        int selectedTemplateId { get; set; }

        event EventHandler eventShowTemplateHandlerView;

        void setTemplateList(List<TemplateModel> templateList);
        void setTemplateFrameList(List<TemplateFrameModel> templateFrameList);
    }
}
