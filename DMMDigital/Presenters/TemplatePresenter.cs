using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
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
            new DialogGenerateTemplatePresenter(new TemplateCreationDialog());
            view.Show();
            getTemplates();
        }

        private void deleteTemplate(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
