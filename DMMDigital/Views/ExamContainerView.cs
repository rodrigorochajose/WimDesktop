using DMMDigital._Repositories;
using DMMDigital.Models;
using DMMDigital.Presenters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ExamContainerView : Form, IExamContainerView
    {
        public int patientId { get; set; }
        public PatientModel patient { get; set; }
        public List<int> openExamsId { get; set; }

        public event EventHandler eventGetPatient;

        public ExamContainerView(IExamView examView)
        {
            InitializeComponent();
            IExamView exam = examView;

            openExamsId = new List<int>
            {
                exam.examId
            };

            tabPage1.Text = exam.sessionName;
            patientId = exam.patientId;
            addFormIntoPage(tabPage1, exam);
        }

        public void addNewPage(IExamView examView)
        {
            TabPage newTabPage = new TabPage
            {
                Name = $"tabPage{tabControl1.TabCount + 1}",
                Size = new Size(1362, 653),
                Text = examView.sessionName,
            };

            tabControl1.Controls.Add(newTabPage);

            addFormIntoPage(newTabPage, examView);
        }

        private void addFormIntoPage(TabPage tabPage, IExamView examView)
        {
            (examView as Form).TopLevel = false;
            (examView as Form).FormBorderStyle = FormBorderStyle.None;
            (examView as Form).AutoScaleMode = AutoScaleMode.Dpi;

            tabPage.Controls.Add(examView as Form);
            (examView as Form).Dock = DockStyle.Fill;
            Show();
            (examView as Form).Show();
        }

        private void buttonNewExamClick(object sender, EventArgs e)
        {
            IChooseTemplateExamView chooseTemplateView = new ChooseTemplateExamView();
            eventGetPatient?.Invoke(this, e);

            chooseTemplateView.patientId = patient.id;
            chooseTemplateView.patientName = patient.name;
            chooseTemplateView.patientBirthDate = patient.birthDate;
            chooseTemplateView.patientPhone = patient.phone;
            chooseTemplateView.patientRecommendation = patient.recommendation;
            chooseTemplateView.patientObservation = patient.observation;

            new ChooseTemplateExamPresenter(chooseTemplateView, new TemplateRepository(), "examView");
        }

        private void buttonOpenExamClick(object sender, EventArgs e)
        {
            new PatientPresenter(new PatientView(), new PatientRepository(), "newPage");
        }

        private void examContainerViewFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms.Cast<Form>().First().Show();
        }

    }
}
