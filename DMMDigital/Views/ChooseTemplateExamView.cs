using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ChooseTemplateExamView : Form, IChooseTemplateExamView
    {
        List<TemplateFrameModel> templateFrameList;

        public ChooseTemplateExamView()
        {
            InitializeComponent();
            associateEvents();

            ActiveControl = textBoxSessionName;
        }

        private void associateEvents()
        {
            buttonNewTemplate.Click += delegate { eventAddNewTemplate?.Invoke(this, EventArgs.Empty); };

            buttonInitializeExam.Click += delegate { eventInitializeExam?.Invoke(this, EventArgs.Empty); };

            buttonCancelAction.Click += delegate { Close(); };

            comboBoxTemplate.SelectionChangeCommitted += delegate { showTemplateOnPanel(); };
        }

        public int patientId { get; set; }

        public string patientName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public DateTime patientBirthDate
        {
            get { return DateTime.Parse(textBoxBirthDate.Text); }
            set { textBoxBirthDate.Text = value.ToString(); }
        }

        public string patientPhone
        {
            get { return textBoxPhone.Text; }
            set { textBoxPhone.Text = value; }
        }

        public string patientRecommendation
        {
            get { return textBoxRecommendation.Text; }
            set { textBoxRecommendation.Text = value; }
        }

        public string patientObservation
        {
            get { return textBoxObservation.Text; }
            set { textBoxObservation.Text = value; }
        }

        public string sessionName 
        {
            get { return textBoxSessionName.Text; }
            set { textBoxSessionName.Text = value; }
        }

        public int selectedTemplateId 
        {
            get { return int.Parse(comboBoxTemplate.SelectedValue.ToString()); }
        }

        public string selectedTemplateName
        { 
            get { return comboBoxTemplate.Text; } 
        }

        public List<TemplateFrameModel> templateFrames
        { 
            get { return templateFrameList.Where(frame => frame.templateId == int.Parse(comboBoxTemplate.SelectedValue.ToString())).ToList(); }
        }

        public event EventHandler eventAddNewTemplate;
        public event EventHandler eventInitializeExam;

        public void setTemplateList(List<TemplateModel> templateList)
        {
            comboBoxTemplate.DataSource = templateList;
            comboBoxTemplate.DisplayMember = "name";
            comboBoxTemplate.ValueMember = "id";
        }

        public void setTemplateFrameList(List<TemplateFrameModel> templateFrameList)
        {
            this.templateFrameList = templateFrameList;
            comboBoxTemplate.SelectedItem = comboBoxTemplate.Items[0];
            showTemplateOnPanel();
        }

        private void showTemplateOnPanel()
        {
            clearTemplatePanel();

            int templateId = int.Parse(comboBoxTemplate.SelectedValue.ToString());

            List<TemplateFrameModel> framesToShow = templateFrameList.Where(tl => tl.templateId == templateId).ToList();

            foreach (TemplateFrameModel tl in framesToShow)
            {
                int height;
                int width;
                if (tl.orientation.Contains("Vertical"))
                {
                    height = 35;
                    width = 25;
                }
                else
                {
                    height = 25;
                    width = 35;
                }

                PictureBox newFrame = new PictureBox
                {
                    Width = width,
                    Height = height,
                    BackColor = Color.Black,
                };


                Bitmap image = new Bitmap(newFrame.Width, newFrame.Height);
                Graphics graphics = Graphics.FromImage(image);
                graphics.DrawString(tl.order.ToString(), new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, new Point(0, 0));
                newFrame.Image = image;
                newFrame.Location = new Point(tl.locationX / 2, tl.locationY / 2);

                panel3.Controls.Add(newFrame);
            }
        }

        private void clearTemplatePanel()
        {
            List<PictureBox> framesOnPanel = panel3.Controls.Cast<PictureBox>().ToList();

            if (!framesOnPanel.Any()) return;
            foreach (PictureBox pb in framesOnPanel)
            {
                panel3.Controls.Remove(pb);
            }
        }
    }
}
