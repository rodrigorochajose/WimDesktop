using DMMDigital.Models;
using System;
using System.Collections.Generic;

namespace DMMDigital.Views
{
    public interface IDialogGenerateTemplate
    {
        string templateName { get; set; }
        List<TemplateFrameModel> templateFrames { get; set; }
        int rows { get; set; }
        int columns { get; set; }
        string orientation { get; set; }

        event EventHandler eventShowTemplateHandlerView;

        void setTemplateList(List<TemplateModel> templateList);
        void setTemplateFrameList(List<TemplateFrameModel> templateFrameList);
    }
}
