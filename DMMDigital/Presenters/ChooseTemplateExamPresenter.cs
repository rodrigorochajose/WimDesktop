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
    public class ChooseTemplateExamPresenter
    {
        private readonly ITemplateExamView chooseTemplateExamView;
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly IConfigRepository configRepository = new ConfigRepository();

        private string examOpeningMode = "newPage";

        public ChooseTemplateExamPresenter(ITemplateExamView view, ITemplateRepository repository, string calledFromView)
        {
            chooseTemplateExamView = view;
            templateRepository = repository;

            chooseTemplateExamView.eventInitializeExam += showExamForm;
            chooseTemplateExamView.eventAddNewTemplate += showAddTemplateForm;

            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
            chooseTemplateExamView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (chooseTemplateExamView as Form).Show();

            (chooseTemplateExamView as Form).FormClosed += delegate
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
                    else
                    {
                        foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                        {
                            form.Show();
                        };
                    }
                }
            };
        }

        private void showExamForm(object sender, EventArgs e)
        {
            PatientModel patient = new PatientModel
            {
                id = chooseTemplateExamView.patientId,
                name = chooseTemplateExamView.patientName,
            };

            ConfigModel config = configRepository.getAllConfig();

            ExamView examView = new ExamView(patient, chooseTemplateExamView.selectedTemplateId, chooseTemplateExamView.templateFrames, chooseTemplateExamView.selectedTemplateName, chooseTemplateExamView.sessionName, config);
            (chooseTemplateExamView as Form).Close();
            Application.OpenForms.Cast<Form>().First().Hide();

            new ExamPresenter(examView, new ExamRepository(), false, examOpeningMode);
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new DialogGenerateTemplatePresenter(new TemplateCreationDialog());
            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
            chooseTemplateExamView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
        }
    }
}
