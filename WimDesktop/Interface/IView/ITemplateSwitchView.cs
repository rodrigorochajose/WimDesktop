using WimDesktop.Models;
using System;
using System.Collections.Generic;

namespace WimDesktop.Interface.IView
{
    public interface ITemplateSwitchView
    {
        int selectedTemplateId { get; set; }
        List<TemplateFrameModel> templateFrameList { get; set; }

        event EventHandler eventAddNewTemplate;
        event EventHandler eventSwitchTemplate;

        void setTemplateList(List<TemplateModel> templateList);
        void setTemplateFrameList(List<TemplateFrameModel> templateFrameList);
        void showCurrentTemplate(int templateId, string templateName);
    }
}
