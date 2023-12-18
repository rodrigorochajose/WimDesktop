using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ChooseTemplateExamPresenter
    {
        private IChooseTemplateExamView chooseTemplateExamView;
        private ITemplateRepository templateRepository;
        private ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        private string openingMode = "add";

        public ChooseTemplateExamPresenter(IChooseTemplateExamView view, ITemplateRepository repository, string calledFromView)
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
                    openingMode = "open";
                    if (calledFromView == "patientView")
                    {
                        foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                        {
                            if (form.Text != "WIM Desktop")
                            {
                                form.Close();
                            }
                            else
                            {
                                form.Show();
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

            (chooseTemplateExamView as Form).Hide();
            (chooseTemplateExamView as Form).Close();
            Application.OpenForms.Cast<Form>().First().Hide();

            ExamView examView = new ExamView(patient, chooseTemplateExamView.selectedTemplateId, chooseTemplateExamView.templateFrames, chooseTemplateExamView.selectedTemplateName, chooseTemplateExamView.sessionName);

            new ExamPresenter(examView, new ExamRepository(), false, openingMode);
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new DialogGenerateTemplatePresenter(new DialogGenerateTemplateView());
            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
        }
    }
}
