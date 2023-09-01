using DMMDigital.Modelos;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DMMDigital.Forms
{
    public partial class ChooseTemplateExamView : Form, IChooseTemplateExamView
    {
        List<TemplateLayoutModel> templateLayoutList;

        public ChooseTemplateExamView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            buttonNewTemplate.Click += delegate { eventAddNewTemplate?.Invoke(this, EventArgs.Empty); };

            buttonCancelAction.Click += delegate { this.Close(); };

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
        public int templateId
        { 
            get { return int.Parse(comboBoxTemplate.SelectedValue.ToString()); }
            set { this.comboBoxTemplate.SelectedValue = value; }
        }


        public event EventHandler eventAddNewTemplate;
        public event EventHandler eventInitializeExam;

        public void setTemplateList(List<TemplateModel> templateList)
        {
            comboBoxTemplate.DataSource = templateList;
            comboBoxTemplate.DisplayMember = "name";
            comboBoxTemplate.ValueMember = "id";
        }

        public void setTemplateLayoutList(List<TemplateLayoutModel> templateLayoutList)
        {
            this.templateLayoutList = templateLayoutList;
            comboBoxTemplate.SelectedItem = comboBoxTemplate.Items[0];
            showTemplateOnPanel();
        }

        private void showTemplateOnPanel()
        {
            clearTemplatePanel();

            int templateId = int.Parse(comboBoxTemplate.SelectedValue.ToString());

            List<TemplateLayoutModel> templateLayoutListToShow = templateLayoutList.Where(tl => tl.templateId == templateId).ToList();

            int height, width;

            foreach (TemplateLayoutModel tl in  templateLayoutListToShow)
            {
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
                Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                graphics.DrawString(tl.order.ToString(), font, Brushes.White, new Point(0, 0));
                newFrame.Image = image;
                newFrame.Location = new Point(tl.locationX / 2, tl.locationY / 2);

                panel3.Controls.Add(newFrame);
            }
        }

        private void clearTemplatePanel()
        {
            List<PictureBox> framesOnPanel = panel3.Controls.Cast<PictureBox>().ToList();

            if (framesOnPanel != null)
            {
                foreach (PictureBox pb in framesOnPanel)
                {
                    panel3.Controls.Remove(pb);
                }
            }
        }
    }
}
