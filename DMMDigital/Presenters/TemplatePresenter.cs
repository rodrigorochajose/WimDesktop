using DMMDigital._Repositories;
using DMMDigital.Interface;
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
        private readonly BindingSource templateBindingSource;
        private IEnumerable<TemplateModel> templateList;


        public TemplatePresenter(ITemplateView view)
        {
            templateBindingSource = new BindingSource();
            templateView = view;

            templateView.eventEditTemplate += editTemplate;
            templateView.eventDeleteTemplate += deleteTemplate;

            templateView.setTemplateList(templateBindingSource);

            getTemplates();

            (templateView as Form).ShowDialog();
        }

        private void deleteTemplate(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(confirmacao))
            {
                MessageBox.Show(templateRepository.delete(templateView.selectedTemplateId));
                getTemplates();
            }
        }

        private void editTemplate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void getTemplates()
        {
            templateList = templateRepository.getAllTemplates();

            if (templateList.Any())
            {
                templateBindingSource.DataSource = templateList;
                templateView.templateDataGridViewHandler();
            }
        }
    }
}
