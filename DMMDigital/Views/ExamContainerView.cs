using DMMDigital.Interface.IView;
using DMMDigital.Properties;
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
        public bool twainInitialized { get; set; }

        public event EventHandler eventConnectSensor;
        public event EventHandler eventDestroySensor;
        public event EventHandler eventGetSensorInfo;
        public event EventHandler eventOpenTwain;
        public event EventHandler eventInitializeTwain;

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
                if (ev.TabPage != null)
                {
                    Form examScreen = ev.TabPage.Controls.OfType<Form>().First();
                    selectedExamView = examScreen as ExamView;
                }
            };
        }

        public void addNewPage(IExamView examView)
        {
            associateEvents(examView);

            TabPage newTabPage = new TabPage
            {
                Name = $"tabPage{tabControl.TabCount + 1}",
                Text = examView.sessionName,
                Margin = new Padding(0)
            };

            selectedExamView = examView as ExamView;
            eventGetSensorInfo?.Invoke(this, EventArgs.Empty);

            openExamsId.Add(examView.examId);
            addFormIntoPage(newTabPage, examView as Form);

            tabControl.TabPages.Add(newTabPage);
            tabControl.SelectedTab = newTabPage;
        }

        private void associateEvents(IExamView examView)
        {
            examView.eventCloseSingleExam += (s, e) =>
            {
                closePage(s, e);
            };

            examView.eventChangeAcquireMode += (s, e) =>
            {
                if (examView.acquireMode == "TWAIN")
                {
                    eventConnectSensor?.Invoke(s, e);
                    examView.acquireMode = Resources.nativeAquireMode;
                }
                else
                {
                    eventDestroySensor?.Invoke(this, e);
                    examView.acquireMode = "TWAIN";

                    if (!twainInitialized)
                    {
                        eventInitializeTwain?.Invoke(this, e);
                    }
                }
            };

            examView.eventAcquireTwain += (s, e) =>
            {
                eventOpenTwain(s, e);
            };
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
            if (tabControl.TabPages.Count == 1)
            {
                Close();
                return;
            }

            openExamsId.Remove((sender as ExamView).examId);

            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Text == (sender as ExamView).sessionName)
                {
                    tabControl.TabPages.Remove(tp);
                    (sender as Form).Close();
                    return;
                }
            }
        }
    }
}
