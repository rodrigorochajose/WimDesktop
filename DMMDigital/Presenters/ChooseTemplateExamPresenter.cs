using DMMDigital._Repositories;
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
        private ITemplateLayoutRepository templateLayoutRepository = new TemplateLayoutRepository();

        public ChooseTemplateExamPresenter(IChooseTemplateExamView view, ITemplateRepository repository)
        {
            chooseTemplateExamView = view;
            templateRepository = repository;

            chooseTemplateExamView.eventInitializeExam += showExamForm;
            chooseTemplateExamView.eventAddNewTemplate += showAddTemplateForm;

            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
            chooseTemplateExamView.setTemplateLayoutList(templateLayoutRepository.getAllTemplateLayout());

            (chooseTemplateExamView as Form).ShowDialog();
        }

        private void showExamForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new DialogGenerateTemplatePresenter(new DialogGenerateTemplateView());
            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
        }
    }
}
