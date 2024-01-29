using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public interface ITemplateView
    {
        int selectedTemplateId { get; set; }

        event EventHandler eventGetTemplates;
        event EventHandler eventNewTemplate;
        event EventHandler eventEditTemplate;
        event EventHandler eventDeleteTemplate;

        void setTemplateList(BindingSource templateList);

        void templateDataGridViewHandler();
    }
}
