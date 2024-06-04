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

        public event EventHandler eventDestroyDetector;

        public ExamContainerView(IExamView examView)
        {
            InitializeComponent();
            IExamView exam = examView;

            examView.eventCloseSingleExam += (s, e) =>
            {
                closePage(s, e);
            };

            openExamsId = new List<int>
            {
                exam.examId
            };

            tabPage1.Text = exam.sessionName;
            addFormIntoPage(tabPage1, exam);
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

            openExamsId.Add(examView.examId);

            tabControl.TabPages.Add(newTabPage);

            addFormIntoPage(newTabPage, examView);

            tabControl.SelectedTab = newTabPage;
        }

        private void addFormIntoPage(TabPage tabPage, IExamView examView)
        {
            (examView as Form).TopLevel = false;
            (examView as Form).Dock = DockStyle.Fill;

            tabPage.Controls.Add(examView as Form);
            Show();
            (examView as Form).Show();
        }

        private void examContainerViewFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms.Cast<Form>().First().Show();
            eventDestroyDetector?.Invoke(this, e);
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
