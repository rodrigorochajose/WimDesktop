using System;
using System.Windows.Forms;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Views;

namespace WimDesktop.Presenters
{
    public class ExamTemplateSelectionPresenter
    {
        private readonly IExamTemplateSelectionView view;
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();


        public ExamTemplateSelectionPresenter(IExamTemplateSelectionView view, int patientId)
        {
            this.view = view;

            view.eventInitializeExam += showExamForm;
            view.eventAddNewTemplate += showAddTemplateForm;

            setPatientData(patientId);

            view.setTemplateList(templateRepository.getAllTemplates());
            view.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (view as Form).Show();
        }

        private void setPatientData(int patientId)
        {
            IPatientRepository patientRepository = new PatientRepository();

            PatientModel patient = patientRepository.getPatientById(patientId);

            view.patientId = patient.id;
            view.patientName = patient.name;
            view.patientBirthDate = patient.birthDate;
            view.patientPhone = patient.phone;
            view.patientRecommendation = patient.recommendation;
            view.patientObservation = patient.observation;
        }

        private void showExamForm(object sender, EventArgs e)
        {
            ExamView examView = new ExamView(view.patientId, view.patientName, view.selectedTemplateId, view.templateFrames, view.selectedTemplateName, view.sessionName, settingsRepository.getAllSettings());

            new ExamPresenter(examView, false);

            new ExamContainerPresenter(new ExamContainerView(examView));

            FormManager.instance.closeAllExceptExamAndMenu();
            FormManager.instance.hideMainForm();

        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new TemplateCreationSetupPresenter(new TemplateCreationSetupView());
            view.setTemplateList(templateRepository.getAllTemplates());
            view.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
        }
    }
}
