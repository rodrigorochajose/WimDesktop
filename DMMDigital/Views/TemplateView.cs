using DMMDigital.Presenters;
using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class TemplateView : Form, ITemplateView
    {
        public int selectedTemplateId { get; set; }

        public event EventHandler eventGetTemplates;
        public event EventHandler eventNewTemplate;
        public event EventHandler eventEditTemplate;
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
                eventNewTemplate?.Invoke(this, EventArgs.Empty);
            };

            dataGridViewTemplate.CellContentClick += (s, e) =>
            {
                if (e.RowIndex != -1)
                {
                    selectedTemplateId = int.Parse(dataGridViewTemplate.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    if (e.ColumnIndex == 0)
                    {
                        eventEditTemplate?.Invoke(this, EventArgs.Empty);
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        eventDeleteTemplate?.Invoke(this, EventArgs.Empty);
                    }
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
            edit.Frozen = true;
            edit.Image = Properties.Resources.icon_32x32_pencil2;
            edit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            delete.Frozen = true;
            delete.Image = Properties.Resources.icon_32x32_delete;
            delete.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
    }
}
