using DMMDigital.Components;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ExamTemplateSelectionView : Form, IExamTemplateSelectionView
    {
        List<TemplateFrameModel> templateFrameList;

        public int patientId { get; set; }

        public string patientName
        {
            get { return textBoxName.InnerTextBox.Text; }
            set { textBoxName.InnerTextBox.Text = value; }
        }

        public DateTime patientBirthDate
        {
            get { return DateTime.Parse(textBoxBirthDate.InnerMaskedTextBox.Text); }
            set { textBoxBirthDate.InnerMaskedTextBox.Text = value.ToString(); }
        }

        public string patientPhone
        {
            get { return textBoxPhone.InnerMaskedTextBox.Text; }
            set { textBoxPhone.InnerMaskedTextBox.Text = value; }
        }

        public string patientRecommendation
        {
            get { return textBoxRecommendation.InnerTextBox.Text; }
            set { textBoxRecommendation.InnerTextBox.Text = value; }
        }

        public string patientObservation
        {
            get { return textBoxObservation.InnerTextBox.Text; }
            set { textBoxObservation.InnerTextBox.Text = value; }
        }

        public string sessionName 
        {
            get { return textBoxSessionName.InnerTextBox.Text; }
            set { textBoxSessionName.InnerTextBox.Text = value; }
        }

        public int selectedTemplateId 
        {
            get { return int.Parse(comboBoxTemplate.InnerControl.SelectedValue.ToString()); }
        }

        public string selectedTemplateName
        { 
            get { return comboBoxTemplate.InnerControl.Text; } 
        }

        public List<TemplateFrameModel> templateFrames
        { 
            get { return templateFrameList.Where(frame => frame.templateId == int.Parse(comboBoxTemplate.InnerControl.SelectedValue.ToString())).ToList(); }
        }

        public event EventHandler eventAddNewTemplate;
        public event EventHandler eventInitializeExam;

        public ExamTemplateSelectionView()
        {
            InitializeComponent();

            textBoxBirthDate.InnerMaskedTextBox.Mask = "00/00/0000";
            textBoxPhone.InnerMaskedTextBox.Mask = "(00) 00000-0000";

            associateEvents();

            ActiveControl = textBoxSessionName;
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    eventInitializeExam?.Invoke(this, EventArgs.Empty);
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                    FormManager.instance.unhideMainForm();
                }
            };

            buttonNewTemplate.Click += delegate 
            { 
                eventAddNewTemplate?.Invoke(this, EventArgs.Empty); 
            };

            buttonInitializeExam.Click += delegate 
            { 
                eventInitializeExam?.Invoke(this, EventArgs.Empty); 
            };

            buttonCancel.Click += delegate 
            { 
                Close();
                FormManager.instance.unhideMainForm();
            };

            comboBoxTemplate.InnerControl.SelectionChangeCommitted += delegate 
            { 
                showTemplateOnPanel(); 
            };

            panelShowTemplate.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panelShowTemplate.ClientRectangle, Color.DarkGray, 2, ButtonBorderStyle.Solid, Color.DarkGray, 2, ButtonBorderStyle.Solid, Color.DarkGray, 2, ButtonBorderStyle.Solid, Color.DarkGray, 2, ButtonBorderStyle.Solid);
            };
        }

        public void setTemplateList(List<TemplateModel> templateList)
        {
            comboBoxTemplate.InnerControl.DataSource = templateList;
            comboBoxTemplate.InnerControl.DisplayMember = "name";
            comboBoxTemplate.InnerControl.ValueMember = "id";
        }

        public void setTemplateFrameList(List<TemplateFrameModel> templateFrameList)
        {
            this.templateFrameList = templateFrameList;
            if (comboBoxTemplate.InnerControl.Items.Count > 0)
            {
                comboBoxTemplate.InnerControl.SelectedItem = comboBoxTemplate.InnerControl.Items[0];
                showTemplateOnPanel();
            }
        }

        private void showTemplateOnPanel()
        {
            clearTemplatePanel();

            int templateId = int.Parse(comboBoxTemplate.InnerControl.SelectedValue.ToString());

            List<TemplateFrameModel> framesToShow = templateFrameList.Where(tl => tl.templateId == templateId).ToList();

            foreach (TemplateFrameModel frame in framesToShow)
            {
                int height;
                int width;
                if (frame.orientation < 2)
                {
                    height = 35;
                    width = 25;
                }
                else
                {
                    height = 25;
                    width = 35;
                }

                Frame newFrame = new Frame
                {
                    Width = width,
                    Height = height,
                    BackColor = Color.Black,
                    orientation = frame.orientation,
                    order = frame.order
                };

                Bitmap image = new Bitmap(newFrame.Width, newFrame.Height);
                Graphics graphics = Graphics.FromImage(image);
                newFrame.Image = image;
                newFrame.Location = new Point(frame.locationX / 2, frame.locationY / 2);

                panelShowTemplate.Controls.Add(newFrame);
            }
        }

        private void clearTemplatePanel()
        {
            List<Frame> framesOnPanel = panelShowTemplate.Controls.Cast<Frame>().ToList();

            if (!framesOnPanel.Any()) return;
            foreach (Frame pb in framesOnPanel)
            {
                panelShowTemplate.Controls.Remove(pb);
            }
        }
    }
}
