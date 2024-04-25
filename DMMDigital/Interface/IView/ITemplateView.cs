using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DMMDigital.Interface.IView
{
    public interface ITemplateView
    {
        List<TemplateFrameModel> templateFrameList { get; set; }
        int selectedTemplateId { get; set; }

        event EventHandler eventGetTemplates;
        event EventHandler showNewTemplateForm;
        event EventHandler eventDeleteTemplate;

        void setTemplateList(BindingSource templateList);

        void templateDataGridViewHandler();
    }
}
