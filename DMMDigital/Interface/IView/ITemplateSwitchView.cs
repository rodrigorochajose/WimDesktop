using DMMDigital.Models;
using System;
using System.Collections.Generic;

namespace DMMDigital.Interface.IView
{
    public interface ITemplateSwitchView
    {
        int selectedTemplateId { get; set; }

        event EventHandler eventAddNewTemplate;
        event EventHandler eventSwitchTemplate;

        void setTemplateList(List<TemplateModel> templateList);
        void setTemplateFrameList(List<TemplateFrameModel> templateFrameList);
        void showCurrentTemplate(int templateId, string templateName);
    }
}
