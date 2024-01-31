using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class TemplateView : Form, ITemplateView
    {
        public List<TemplateFrameModel> templateFrameList { get; set; }
        public int selectedTemplateId { get; set; }

        public event EventHandler eventGetTemplates;
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
                    if (e.ColumnIndex == 1)
                    {
                        eventDeleteTemplate?.Invoke(this, EventArgs.Empty);
                    }
                }
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

                panelTemplate.Controls.Add(newFrame);
            }
        }

        private void clearTemplatePanel()
        {
            List<PictureBox> framesOnPanel = panelTemplate.Controls.Cast<PictureBox>().ToList();

            if (!framesOnPanel.Any()) return;
            foreach (PictureBox pb in framesOnPanel)
            {
                panelTemplate.Controls.Remove(pb);
            }
        }
    }
}
