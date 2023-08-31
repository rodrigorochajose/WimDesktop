using DMMDigital.Interface;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ChooseTemplateExamPresenter
    {
        private IChooseTemplateExamView chooseTemplateExamView;
        private ITemplateRepository templateRepository;

        public ChooseTemplateExamPresenter(IChooseTemplateExamView view, ITemplateRepository repository)
        {
            chooseTemplateExamView = view;
            templateRepository = repository;

            chooseTemplateExamView.eventInitializeExam += showExamForm;
            chooseTemplateExamView.eventAddNewTemplate += showAddTemplateForm;

            chooseTemplateExamView.setTemplateList(repository.getAllTemplates());

            (chooseTemplateExamView as Form).ShowDialog();
        }

        private void showExamForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new DialogGenerateTemplatePresenter(new DialogGenerateTemplateView());
        }
    }
}
