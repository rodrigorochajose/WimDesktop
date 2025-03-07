using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ExamTemplateSelectionPresenter
    {
        private readonly IExamTemplateSelectionView view;
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        private string examOpeningMode = "newPage";

        public ExamTemplateSelectionPresenter(IExamTemplateSelectionView view, Type calledFromView)
        {
            this.view = view;

            if (calledFromView != typeof(ExamView))
            {
                examOpeningMode = "newContainer";
            }

            view.eventInitializeExam += showExamForm;
            view.eventAddNewTemplate += showAddTemplateForm;

            view.setTemplateList(templateRepository.getAllTemplates());
            view.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (view as Form).Show();
        }

        private void showExamForm(object sender, EventArgs e)
        {
            PatientModel patient = new PatientModel
            {
                id = view.patientId,
                name = view.patientName,
            };

            FormManager.instance.closeAllExceptExamAndMenu();

            ExamView examView = new ExamView(patient, view.selectedTemplateId, view.templateFrames, view.selectedTemplateName, view.sessionName);
            new ExamPresenter(examView, false, examOpeningMode);
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new TemplateCreationSetupPresenter(new TemplateCreationSetupView());
            view.setTemplateList(templateRepository.getAllTemplates());
            view.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
        }
    }
}
