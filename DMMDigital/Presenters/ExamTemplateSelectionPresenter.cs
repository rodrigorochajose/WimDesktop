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

            view.eventInitializeExam += showExamForm;
            view.eventAddNewTemplate += showAddTemplateForm;

            view.setTemplateList(templateRepository.getAllTemplates());
            view.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (view as Form).Show();

            (view as Form).FormClosed += delegate
            {
                if (calledFromView != typeof(ExamView))
                {
                    examOpeningMode = "newContainer";

                    FormCollection openForms = Application.OpenForms;

                    for (int counter = 0; counter < openForms.Count; counter++)
                    {
                        if (openForms[counter].GetType() == typeof(MenuView))
                        {
                            openForms[counter].Show();
                            continue;
                        }

                        openForms[counter].Close();
                    };
                }
            };
        }

        private void showExamForm(object sender, EventArgs e)
        {
            PatientModel patient = new PatientModel
            {
                id = view.patientId,
                name = view.patientName,
            };

            ExamView examView = new ExamView(patient, view.selectedTemplateId, view.templateFrames, view.selectedTemplateName, view.sessionName);
            (view as Form).Close();
            Application.OpenForms.Cast<Form>().First().Hide();

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
