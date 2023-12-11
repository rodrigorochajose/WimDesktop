using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ExamContainerView : Form
    {
        ExamView exam;

        public ExamContainerView(ExamView examview)
        {
            InitializeComponent();
            exam = examview;
            Show();
        }

        private void examContainerViewLoad(object sender, EventArgs e)
        {
            addFormIntoPage(tabPage1, exam);
            Refresh();
            Show();
        }
        private void addFormIntoPage(TabPage tabPage, ExamView examview)
        {
            examview.TopLevel = false;
            examview.FormBorderStyle = FormBorderStyle.None;
            examview.AutoScaleMode = AutoScaleMode.Dpi;

            tabPage.Controls.Add(examview);
            examview.Dock = DockStyle.Fill;
            examview.Show();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TabPage newTabPage = new TabPage
            //{
            //    Name = $"tabPage{tabControl1.TabCount + 1}",
            //    Size = new Size(1362, 653),
            //    Text = $"tabPage{tabControl1.TabCount + 1}",
            //};

            //tabControl1.Controls.Add(newTabPage);

            //addFormIntoPage(newTabPage);

            //Refresh();
        }
        

    }
}
