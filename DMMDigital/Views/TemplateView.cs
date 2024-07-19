using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Interface.IView;
using DMMDigital.Components;

namespace DMMDigital.Views
{
    public partial class TemplateView : Form, ITemplateView
    {
        public List<TemplateFrameModel> templateFrameList { get; set; }
        public int selectedTemplateId { get; set; }

        public event EventHandler showNewTemplateForm;
        public event EventHandler eventDeleteTemplate;

        public TemplateView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            buttonNewTemplate.Click += delegate
            {
                showNewTemplateForm?.Invoke(this, EventArgs.Empty);
            };

            dataGridViewTemplate.CellContentClick += (s, e) =>
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        eventDeleteTemplate?.Invoke(this, EventArgs.Empty);
                    }
                }
            };

            panelShowTemplate.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panelShowTemplate.ClientRectangle, Color.DarkGray, 2, ButtonBorderStyle.Solid, Color.DarkGray, 2, ButtonBorderStyle.Solid, Color.DarkGray, 2, ButtonBorderStyle.Solid, Color.DarkGray, 2, ButtonBorderStyle.Solid);
            };
        }

        private void templateViewLoad(object sender, EventArgs e)
        {
            showTemplateOnPanel();

            dataGridViewTemplate.CurrentCellChanged += (s, ev) =>
            {
                if (dataGridViewTemplate.CurrentCell != null)
                {
                    selectedTemplateId = int.Parse(dataGridViewTemplate.CurrentCell.OwningRow.Cells["id"].Value.ToString());
                    showTemplateOnPanel();
                }
            };
        }

        public void setTemplateList(BindingSource templateList)
        {
            dataGridViewTemplate.DataSource = templateList;
        }

        public void templateDataGridViewHandler()
        {
            dataGridViewTemplate.Columns["id"].Visible = false;
            delete.Frozen = true;
            delete.Image = Properties.Resources.icon_32x32_delete;
            delete.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void showTemplateOnPanel()
        {
            clearTemplatePanel();

            if (selectedTemplateId == 0)
            {
                selectedTemplateId = int.Parse(dataGridViewTemplate.CurrentCell.OwningRow.Cells["id"].Value.ToString());
            }

            List<TemplateFrameModel> framesToShow = templateFrameList.Where(tl => tl.templateId == selectedTemplateId).ToList();

            foreach (TemplateFrameModel frame in framesToShow)
            {
                int height;
                int width;
                if (frame.orientation.Contains("Vertical"))
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
