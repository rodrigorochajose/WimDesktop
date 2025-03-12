using DMMDigital.Components;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class TemplateCreationSetupView : Form, ITemplateCreationSetupView
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "messageTemplateRequiredName")]
        public string templateName 
        { 
            get { return roundedTextBoxTemplateName.Texts; } 
            set { roundedTextBoxTemplateName.Texts = value; } 
        }

        public bool generateByTemplate
        { 
            get { return checkBoxGenerateMode.Checked; }
            set { checkBoxGenerateMode.Checked = value; }
        }

        public int rows
        { 
            get { return decimal.ToInt32(numericUpDownRows.InnerNumericUpDown.Value); }
            set { numericUpDownRows.InnerNumericUpDown.Value = value; } 
        }

        public int columns
        { 
            get { return decimal.ToInt32(numericUpDownColumns.InnerNumericUpDown.Value); }
            set { numericUpDownColumns.InnerNumericUpDown.Value = value; } 
        }

        public int orientation
        { 
            get { return comboBoxOrientation.InnerControl.SelectedIndex; }
            set { comboBoxOrientation.InnerControl.SelectedIndex = value; } 
        }

        public int selectedTemplateId
        {
            get { return int.Parse(comboBoxTemplate.InnerControl.SelectedValue.ToString()); }
            set { comboBoxTemplate.InnerControl.SelectedValue = value; }
        }

        public List<TemplateFrameModel> templateFrames { get; set; }

        public event EventHandler eventShowTemplateHandlerView;

        private enum enumDict
        {
            verticalTop,
            verticalBottom,
            horizontalLeft,
            horizontalRight
        };

        private readonly Dictionary<enumDict, string> dictOrientation = new Dictionary<enumDict, string>
        {
            { enumDict.verticalTop, Resources.textVerticalTop },
            { enumDict.verticalBottom, Resources.textVerticalBottom },
            { enumDict.horizontalLeft, Resources.textHorizontalLeft },
            { enumDict.horizontalRight, Resources.textHorizontalRight }
        };

        public TemplateCreationSetupView()
        {
            InitializeComponent();
            associateEvents();

            comboBoxOrientation.InnerControl.DataSource = dictOrientation.ToList();
            comboBoxOrientation.InnerControl.DisplayMember = "Value";
            comboBoxOrientation.InnerControl.ValueMember = "Key";

            panelGenerateDefault.Location = new Point((panelGenerateTemplate.Width - panelGenerateDefault.Width) / 2, panelGenerateDefault.Location.Y);
            panelGenerateByTemplate.Location = new Point((panelGenerateTemplate.Width - panelGenerateByTemplate.Width) / 2, panelGenerateByTemplate.Location.Y);

            ActiveControl = roundedTextBoxTemplateName;
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    eventShowTemplateHandlerView?.Invoke(this, EventArgs.Empty);
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            comboBoxTemplate.InnerControl.SelectionChangeCommitted += delegate 
            { 
                showTemplateOnPanel(); 
            };

            buttonGenerateTemplate.Click += delegate 
            { 
                eventShowTemplateHandlerView?.Invoke(this, EventArgs.Empty); 
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

        public void setTemplateFrameList(List<TemplateFrameModel> templateFrames)
        {
            this.templateFrames = templateFrames;
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
            List<TemplateFrameModel> framesToShow = templateFrames.Where(tl => tl.templateId == templateId).ToList();

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

            if (!framesOnPanel.Any())
            {
                return;
            }

            foreach (Frame pb in framesOnPanel)
            {
                panelShowTemplate.Controls.Remove(pb);
            }
        }

        private void checkBoxGenerateModeCheckedChanged(object sender, EventArgs e)
        {
            panelGenerateDefault.Visible = !checkBoxGenerateMode.Checked;
            panelGenerateByTemplate.Visible = checkBoxGenerateMode.Checked;
        }
    }
}
