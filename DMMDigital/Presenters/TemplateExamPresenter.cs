using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class TemplateExamPresenter
    {
        private readonly ITemplateExamView templateExamView;
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        private string examOpeningMode = "newPage";

        public TemplateExamPresenter(ITemplateExamView view, Type calledFromView)
        {
            templateExamView = view;

            templateExamView.eventInitializeExam += showExamForm;
            templateExamView.eventAddNewTemplate += showAddTemplateForm;

            templateExamView.setTemplateList(templateRepository.getAllTemplates());
            templateExamView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (templateExamView as Form).Show();

            (templateExamView as Form).FormClosed += delegate
            {
                if (calledFromView != typeof(ExamView))
                {
                    examOpeningMode = "newContainer";

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.GetType() == typeof(MenuView))
                        {
                            form.Show();
                            continue;
                        }

                        form.Close();
                    };
                }
            };
        }

        private void showExamForm(object sender, EventArgs e)
        {
            PatientModel patient = new PatientModel
            {
                id = templateExamView.patientId,
                name = templateExamView.patientName,
            };

            ExamView examView = new ExamView(patient, templateExamView.selectedTemplateId, templateExamView.templateFrames, templateExamView.selectedTemplateName, templateExamView.sessionName);
            (templateExamView as Form).Close();
            Application.OpenForms.Cast<Form>().First().Hide();

            new ExamPresenter(examView, false, examOpeningMode);
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new TemplateCreationDialogPresenter(new TemplateCreationDialog());
            templateExamView.setTemplateList(templateRepository.getAllTemplates());
            templateExamView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
        }
    }
}
