using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class TemplatePresenter
    {
        private readonly ITemplateView templateView;
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly BindingSource templateBindingSource;
        private IEnumerable<TemplateModel> templateList;


        public TemplatePresenter(ITemplateView view)
        {
            templateBindingSource = new BindingSource();
            templateView = view;

            templateView.showNewTemplateForm += showNewTemplateForm;
            templateView.eventDeleteTemplate += deleteTemplate;

            templateView.setTemplateList(templateBindingSource);

            getTemplates();

            (templateView as Form).Show();
        }

        private void showNewTemplateForm(object sender, EventArgs e)
        {
            (templateView as Form).Hide();
            new DialogGenerateTemplatePresenter(new DialogGenerateTemplate());
            (templateView as Form).Show();
            getTemplates();
        }

        private void deleteTemplate(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(confirmacao))
            {
                templateRepository.delete(templateView.selectedTemplateId);
                getTemplates();
            }
        }

        private void getTemplates()
        {
            templateList = templateRepository.getAllTemplates();

            if (templateList.Any())
            {
                templateView.templateFrameList = templateFrameRepository.getAllTemplateFrame();

                templateBindingSource.DataSource = templateList;
                templateView.templateDataGridViewHandler();
            }
        }
    }
}
