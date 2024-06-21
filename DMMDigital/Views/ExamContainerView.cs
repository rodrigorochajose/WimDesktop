using DMMDigital.Interface.IView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ExamContainerView : Form, IExamContainerView
    {
        public int patientId { get; set; }
        public List<int> openExamsId { get; set; }
        public ExamView selectedExamView { get; set; }

        public event EventHandler eventDestroySensor;
        public event EventHandler eventGetSensorInfo;

        public ExamContainerView(IExamView examView)
        {
            openExamsId = new List<int>();
            
            selectedExamView = examView as ExamView;
        }

        public void initialize()
        {
            InitializeComponent();
            addNewPage(selectedExamView);
        }

        private void examContainerViewLoad(object sender, EventArgs e)
        {
            tabControl.Selected += (s, ev) =>
            {
                Form examScreen = ev.TabPage.Controls.OfType<Form>().First();
                selectedExamView = examScreen as ExamView;
            };
        }

        public void addNewPage(IExamView examView)
        {
            TabPage newTabPage = new TabPage
            {
                Name = $"tabPage{tabControl.TabCount + 1}",
                Text = examView.sessionName,
                Margin = new Padding(0)
            };

            examView.eventCloseSingleExam += (s, e) =>
            {
                closePage(s, e);
            };

            selectedExamView = examView as ExamView;
            eventGetSensorInfo?.Invoke(this, EventArgs.Empty);

            openExamsId.Add(examView.examId);
            addFormIntoPage(newTabPage, examView as Form);

            tabControl.TabPages.Add(newTabPage);
            tabControl.SelectedTab = newTabPage;
        }

        private void addFormIntoPage(TabPage tabPage, Form examView)
        {
            examView.TopLevel = false;
            examView.Dock = DockStyle.Fill;

            tabPage.Controls.Add(examView);
            examView.Show();
            Show();
        }

        private void examContainerViewFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms.Cast<Form>().First().Show();
            eventDestroySensor?.Invoke(this, e);
        }

        private void examContainerViewFormClosing(object sender, FormClosingEventArgs e)
        {
            List<ExamView> openedExams = Application.OpenForms.OfType<ExamView>().ToList();

            foreach (ExamView exam in openedExams)
            {
                exam.Close();
            }
        }

        private void closePage(object sender, EventArgs e)
        {
            openExamsId.Remove((sender as ExamView).examId);

            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Text == (sender as ExamView).sessionName)
                {
                    tabControl.TabPages.Remove(tp);
                    (sender as Form).Close();
                }
            }

            if (tabControl.TabPages.Count == 0)
            {
                Close();
            }
        }

    }
}
