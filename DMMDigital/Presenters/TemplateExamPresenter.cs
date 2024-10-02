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
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly IConfigRepository configRepository = new ConfigRepository();

        private string examOpeningMode = "newPage";

        public TemplateExamPresenter(ITemplateExamView view, ITemplateRepository repository, string calledFromView)
        {
            templateExamView = view;
            templateRepository = repository;

            templateExamView.eventInitializeExam += showExamForm;
            templateExamView.eventAddNewTemplate += showAddTemplateForm;

            templateExamView.setTemplateList(templateRepository.getAllTemplates());
            templateExamView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (templateExamView as Form).Show();

            (templateExamView as Form).FormClosed += delegate
            {
                if (calledFromView != "examView")
                {
                    examOpeningMode = "newContainer";
                    if (calledFromView == "patientView")
                    {
                        foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                        {
                            if (form.Text.Contains("WIM Desktop"))
                            {
                                form.Show();
                            }
                            else
                            {
                                form.Close();
                            }
                        };
                    }
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

            ConfigModel config = configRepository.getAllConfig();

            ExamView examView = new ExamView(patient, templateExamView.selectedTemplateId, templateExamView.templateFrames, templateExamView.selectedTemplateName, templateExamView.sessionName, config);
            (templateExamView as Form).Close();
            Application.OpenForms.Cast<Form>().First().Hide();

            new ExamPresenter(examView, new ExamRepository(), false, examOpeningMode);
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new TemplateCreationDialogPresenter(new TemplateCreationDialog());
            templateExamView.setTemplateList(templateRepository.getAllTemplates());
            templateExamView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
        }
    }
}
