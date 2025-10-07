using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Presenters;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class ExamContainerView : Form, IExamContainerView
    {
        public int patientId { get; set; }
        public List<ExamModel> patientExams { get; set; }
        public ExamView selectedExamView { get; set; }
        public bool twainInitialized { get; set; }
        public bool sensorConnected { get; set; }

        private readonly SettingsModel settings;

        public event EventHandler eventConnectSensor;
        public event EventHandler eventDestroySensor;
        public event EventHandler eventSetSensorInfo;
        public event EventHandler eventOpenTwain;
        public event EventHandler eventInitializeTwain;
        public event EventHandler eventCloseTwain;

        public ExamContainerView(ExamView view, int patientId)
        {
            InitializeComponent();
            DoubleBuffered = true;

            selectedExamView = view;
            this.patientId = patientId;
        }

        public ExamContainerView(List<ExamModel> patientExams, int patientId, SettingsModel settings)
        {
            InitializeComponent();
            DoubleBuffered = true;

            this.patientExams = patientExams;
            this.settings = settings;
            this.patientId = patientId;
        }

        public void loadDataAndShow()
        {
            Opacity = 0;
            Show();

            SuspendLayout();

            if (selectedExamView != null)
            {
                createExamPage(selectedExamView);
            }
            else if (patientExams != null && patientExams.Any())
            {
                ExamView firstExamView = generateExamView(patientExams.First());
                createExamPage(firstExamView);
                loadContainerContent();
            }

            ResumeLayout(true);

            Opacity = 100;

            if (!sensorConnected)
            {
                MessageBox.Show(Resources.messageSensorCannotConnect);
            }
        }

        private void loadContainerContent()
        {
            foreach (ExamModel exam in patientExams.Skip(1))
            {
                TabPage newTabPage = new TabPage
                {
                    Name = $"tabPage{tabControl.TabCount + 1}",
                    Text = exam.createdAt.ToString(),
                    Tag = false
                };

                tabControl.TabPages.Add(newTabPage);
            }
        }

        private ExamView generateExamView(ExamModel exam)
        {
            ExamView newExamView = new ExamView(exam, patientId, settings);

            new ExamPresenter(newExamView, true);

            return newExamView;
        }

        public void createExamPage(IExamView examView)
        {
            TabPage newTabPage = new TabPage
            {
                Name = $"tabPage{tabControl.TabCount + 1}",
                Text = examView.exam.createdAt.ToString(),
                Tag = true
            };

            selectedExamView = examView as ExamView;

            loadExamIntoPage(newTabPage, examView as Form);

            tabControl.TabPages.Add(newTabPage);
            tabControl.SelectedTab = newTabPage;
        }

        private void loadExamIntoPage(TabPage tabPage, Form examView)
        {
            associateExamEvents(examView as IExamView);

            eventSetSensorInfo?.Invoke(this, EventArgs.Empty);

            examView.TopLevel = false;
            examView.Dock = DockStyle.Fill;

            tabPage.Controls.Add(examView);
            examView.Show();
        }

        private void associateExamEvents(IExamView examView)
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
                if (!twainInitialized)
                {
                    eventInitializeTwain?.Invoke(this, e);
                }

                eventOpenTwain?.Invoke(s, e);
            };
        }

        private void examContainerViewLoad(object sender, EventArgs e)
        {
            tabControl.Selected += (s, ev) =>
            {
                if (!(bool)ev.TabPage.Tag)
                {
                    ExamModel selectedExam = patientExams.FirstOrDefault(ex => ev.TabPage.Text == ex.createdAt.ToString());

                    if (selectedExam == null)
                    {
                        MessageBox.Show(Resources.messageExamErrorOnLoad);
                    }
                    ev.TabPage.Tag = true;

                    selectedExamView = generateExamView(selectedExam);
                    loadExamIntoPage(ev.TabPage, selectedExamView);
                }
            };
        }

        private void examContainerViewFormClosed(object sender, FormClosedEventArgs e)
        {
            FormManager.instance.showMainForm();
            eventDestroySensor?.Invoke(this, e);
        }

        private void examContainerViewFormClosing(object sender, FormClosingEventArgs e)
        {
            List<ExamView> openedExams = Application.OpenForms.OfType<ExamView>().ToList();

            openedExams.ForEach(exam => exam.Close());

            eventCloseTwain?.Invoke(this, e);
        }

        private void closePage(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count == 1)
            {
                Close();
                return;
            }

            foreach (TabPage tp in tabControl.TabPages)
            {
                if (tp.Text == (sender as ExamView).exam.sessionName)
                {
                    tabControl.TabPages.Remove(tp);
                    (sender as Form).Close();
                    return;
                }
            }
        }

        private void tabControlDrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];

            Color backColor = e.Index == tabControl.SelectedIndex ? Color.FromArgb(191, 229, 235) : Color.White;
            Color textColor = Color.Black;

            using (Brush backBrush = new SolidBrush(backColor))
            using (Brush textBrush = new SolidBrush(textColor))
            using (Font font = new Font("Segoe UI", 8))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);

                StringFormat stringFormat = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(tabPage.Text, font, textBrush, e.Bounds, stringFormat);
            }
        }
    }
}
