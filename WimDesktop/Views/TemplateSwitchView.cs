using WimDesktop.Components;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Views
{
    public partial class TemplateSwitchView : Form, ITemplateSwitchView
    {
        public int selectedTemplateId { get; set; }
        public List<TemplateFrameModel> templateFrameList { get; set; }

        public event EventHandler eventAddNewTemplate;
        public event EventHandler eventSwitchTemplate;

        public TemplateSwitchView()
        {
            InitializeComponent();

            associateEvents();
        }

        private void associateEvents()
        {
            comboBoxTemplate.InnerControl.SelectionChangeCommitted += delegate
            {
                selectedTemplateId = int.Parse(comboBoxTemplate.InnerControl.SelectedValue.ToString());

                showTemplateOnPanel();
            };

            buttonNewTemplate.Click += delegate
            {
                eventAddNewTemplate?.Invoke(this, EventArgs.Empty);
            };

            buttonCancel.Click += delegate
            {
                Close();
            };

            buttonSwitchTemplate.Click += delegate
            {
                eventSwitchTemplate?.Invoke(this, EventArgs.Empty);
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
                selectedTemplateId = templateFrameList.First().id;
                showTemplateOnPanel();
            }
        }

        private void showTemplateOnPanel()
        {
            clearTemplatePanel();

            List<TemplateFrameModel> framesToShow = templateFrameList.Where(tl => tl.templateId == selectedTemplateId).ToList();

            List<Frame> frames = generateFrames(framesToShow);

            panelShowTemplate.Controls.AddRange(frames.ToArray());
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

        public void showCurrentTemplate(int templateId, string templateName)
        {
            labelCurrentTemplate.Text += $" - {templateName}";

            List<TemplateFrameModel> framesToShow = templateFrameList.Where(tl => tl.templateId == templateId).ToList();

            List<Frame> frames = generateFrames(framesToShow);

            panelCurrentTemplate.Controls.AddRange(frames.ToArray());
        }

        private List<Frame> generateFrames(List<TemplateFrameModel> framesToGenerate)
        {
            List<Frame> framesList = new List<Frame>();

            foreach (TemplateFrameModel frame in framesToGenerate)
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
                newFrame.Image = image;
                newFrame.Location = new Point(frame.locationX / 2, frame.locationY / 2);

                framesList.Add(newFrame);
            }

            return framesList;
        }
    }
}
