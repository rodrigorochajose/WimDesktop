using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class DialogGenerateTemplate : Form, IDialogGenerateTemplate
    {
        public List<TemplateFrameModel> templateFrames { get; set; }

        [Required(ErrorMessage = "Nome do Template é obrigatório.")]
        public string templateName 
        { 
            get { return textBoxTemplateName.Text; } 
            set { textBoxTemplateName.Text = value; } 
        }

        public int rows
        { 
            get { return decimal.ToInt32(numericUpDownRows.Value); }
            set { numericUpDownRows.Value = value; } 
        }

        public int columns
        { 
            get { return decimal.ToInt32(numericUpDownColumns.Value); }
            set { numericUpDownColumns.Value = value; } 
        }

        public string orientation
        { 
            get { return listBoxOrientation.Text; }
            set { listBoxOrientation.Text = value; } 
        }

        public event EventHandler eventShowTemplateHandlerView;

        public DialogGenerateTemplate()
        {
            InitializeComponent();
            associateEvents();

            listBoxOrientation.SelectedItem = listBoxOrientation.Items[0];

            ActiveControl = textBoxTemplateName;
        }

        private void associateEvents()
        {
            panel2.Paint += (s, e) =>
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), new Point(370, 20), new Point(370, 300));
            };

            comboBoxTemplate.SelectionChangeCommitted += delegate { showTemplateOnPanel(); };

            buttonGenerateTemplate.Click += delegate { eventShowTemplateHandlerView?.Invoke(this, EventArgs.Empty); };
        }

        public void setTemplateList(List<TemplateModel> templateList)
        {
            comboBoxTemplate.DataSource = templateList;
            comboBoxTemplate.DisplayMember = "name";
            comboBoxTemplate.ValueMember = "id";
        }

        public void setTemplateFrameList(List<TemplateFrameModel> templateFrames)
        {
            this.templateFrames = templateFrames;
            if (comboBoxTemplate.Items.Count > 0)
            {
                comboBoxTemplate.SelectedItem = comboBoxTemplate.Items[0];
                showTemplateOnPanel();
            }
        }

        private void showTemplateOnPanel()
        {
            clearTemplatePanel();

            int templateId = int.Parse(comboBoxTemplate.SelectedValue.ToString());

            List<TemplateFrameModel> framesToShow = templateFrames.Where(tl => tl.templateId == templateId).ToList();

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

                panelShowTemplate.Controls.Add(newFrame);
            }
        }

        private void clearTemplatePanel()
        {
            List<PictureBox> framesOnPanel = panelShowTemplate.Controls.Cast<PictureBox>().ToList();

            if (!framesOnPanel.Any()) return;
            foreach (PictureBox pb in framesOnPanel)
            {
                panelShowTemplate.Controls.Remove(pb);
            }
        }

        private void checkBoxGenerateModeCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxGenerateMode.Checked)
            {
                panelGenerateByTemplate.Enabled = true;
                panelShowTemplate.Enabled = true;

                panelGenerateDefault.Enabled = false;
                listBoxOrientation.SelectedItem = null;
            }
            else
            {
                panelGenerateByTemplate.Enabled = false;
                panelShowTemplate.Enabled = false;

                panelGenerateDefault.Enabled = true;
                listBoxOrientation.SelectedItem = listBoxOrientation.Items[0];
            }
        }
    }
}
