using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using WimDesktop.Properties;
using WimDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class TemplatePresenter
    {
        public TemplateView view { get; }

        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly BindingSource templateBindingSource;
        private IEnumerable<TemplateModel> templateList;


        public TemplatePresenter(TemplateView templateView)
        {
            templateBindingSource = new BindingSource();
            view = templateView;

            view.showNewTemplateForm += showNewTemplateForm;
            view.eventDeleteTemplate += deleteTemplate;

            view.setTemplateList(templateBindingSource);

            getTemplates();
        }

        private void showNewTemplateForm(object sender, EventArgs e)
        {
            view.Hide();
            new TemplateCreationSetupPresenter(new TemplateCreationSetupView());
            view.Show();
            getTemplates();
        }

        private void deleteTemplate(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(Resources.messageConfirmDelete, Resources.titleDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(res))
            {
                templateRepository.delete(view.selectedTemplateId);
                getTemplates();
            }
        }

        private void getTemplates()
        {
            templateList = templateRepository.getAllTemplates();

            if (templateList.Any())
            {
                view.templateFrameList = templateFrameRepository.getAllTemplateFrame();

                templateBindingSource.DataSource = templateList;
                view.templateDataGridViewHandler();
            }
        }
    }
}
