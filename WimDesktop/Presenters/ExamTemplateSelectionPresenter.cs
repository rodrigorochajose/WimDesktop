using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Views;
using System;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class ExamTemplateSelectionPresenter
    {
        private readonly IExamTemplateSelectionView view;
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

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

            ExamView examView = new ExamView(patient, view.selectedTemplateId, view.templateFrames, view.selectedTemplateName, view.sessionName, settingsRepository.getAllSettings());

            FormManager.instance.closeAllExceptExamAndMenu();

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
