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

        public ChooseTemplateExamPresenter(IChooseTemplateExamView view, ITemplateRepository repository, bool calledFromPatientView)
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
                if (calledFromPatientView)
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
            };
        }

        private void showExamForm(object sender, EventArgs e)
        {
            PatientModel patient = new PatientModel
            {
                id = chooseTemplateExamView.patientId,
                name = chooseTemplateExamView.patientName,
            };

            new ExamPresenter(new ExamView(patient, chooseTemplateExamView.selectedTemplateId, chooseTemplateExamView.templateFrames, chooseTemplateExamView.selectedTemplateName, chooseTemplateExamView.sessionName), new ExamRepository());
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new DialogGenerateTemplatePresenter(new DialogGenerateTemplateView());
            chooseTemplateExamView.setTemplateList(templateRepository.getAllTemplates());
        }
    }
}
