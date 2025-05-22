using WimDesktop.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WimDesktop.Interface.IView
{
    public interface ITemplateView
    {
        List<TemplateFrameModel> templateFrameList { get; set; }
        int selectedTemplateId { get; set; }

        event EventHandler showNewTemplateForm;
        event EventHandler eventDeleteTemplate;

        void setTemplateList(BindingSource templateList);

        void templateDataGridViewHandler();
    }
}
