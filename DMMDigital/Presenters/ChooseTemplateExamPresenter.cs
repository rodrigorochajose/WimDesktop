using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Modelos;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ChooseTemplateExamPresenter
    {
        private IChooseTemplateExamView chooseTemplateExamView;
        private ITemplateRepository templateRepository;
        private ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public ChooseTemplateExamPresenter(IChooseTemplateExamView view, ITemplateRepository repository)
        {
            chooseTemplateExamView = view;
            templateRepository = repository;

            chooseTemplateExamView.eventInitializeExam += showExamForm;
            chooseTemplateExamView.eventAddNewTemplate += showAddTemplateForm;

            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
            chooseTemplateExamView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (chooseTemplateExamView as Form).ShowDialog();
        }

        private void showExamForm(object sender, EventArgs e)
        {
            PatientModel patient = new PatientModel
            {
                id = chooseTemplateExamView.patientId,
                name = chooseTemplateExamView.patientName,
            };
            new ExamPresenter(new ExamView(patient, chooseTemplateExamView.templateFrames, chooseTemplateExamView.selectedFrameName, chooseTemplateExamView.sessionName), new ExamRepository());

        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new DialogGenerateTemplatePresenter(new DialogGenerateTemplateView());
            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
        }
    }
}
