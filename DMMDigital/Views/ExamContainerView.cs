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
        public List<int> openExamsId { get; set; }

        public event EventHandler eventDestroyDetector;

        public ExamContainerView(IExamView examView)
        {
            InitializeComponent();
            IExamView exam = examView;

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
                Size = new Size(1362, 653),
                Text = examView.sessionName,
            };

            tabControl.Controls.Add(newTabPage);

            addFormIntoPage(newTabPage, examView);
        }

        private void addFormIntoPage(TabPage tabPage, IExamView examView)
        {
            (examView as Form).TopLevel = false;
            (examView as Form).AutoScaleMode = AutoScaleMode.Dpi;

            tabPage.Controls.Add(examView as Form);
            (examView as Form).Dock = DockStyle.Fill;
            Show();
            (examView as Form).Show();
        }

        private void examContainerViewFormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms.Cast<Form>().First().Show();
            eventDestroyDetector?.Invoke(this, e);
        }
    }
}
