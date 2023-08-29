using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class PatientView : Form, IPatientView
    {
        public PatientView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            textBoxSearchPatient.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    eventSearchPatient?.Invoke(this, EventArgs.Empty);
            };

            dataGridViewPatient.CellContentClick += (s, e) =>
            {
                if (e.RowIndex != -1)
                {
                    selectedPatientId = int.Parse(dataGridViewPatient.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    if (e.ColumnIndex == 0)
                    {
                        eventShowEditPatientForm?.Invoke(this, EventArgs.Empty);
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        eventDeletePatient?.Invoke(this, EventArgs.Empty);
                    }
                }
            };

            buttonSearchPatient.Click += delegate { eventSearchPatient?.Invoke(this, EventArgs.Empty); };

            buttonNewPatient.Click += delegate { eventShowAddPatientForm?.Invoke(this, EventArgs.Empty); };

            buttonNewExam.Click += delegate { eventShowFormNewExam?.Invoke(this, EventArgs.Empty); };

            buttonOpenExam.Click += delegate { eventOpenExam?.Invoke(this, EventArgs.Empty); };

            buttonDeleteExam.Click += delegate { eventDeleteExam?.Invoke(this, EventArgs.Empty); };

            buttonExportExam.Click += delegate { eventExportExam?.Invoke(this, EventArgs.Empty); };

        }

        public string searchedValue 
        {
            get { return textBoxSearchPatient.Text; }
            set { textBoxSearchPatient.Text = value; }
        }
        public int selectedPatientId { get; set; }

        public event EventHandler eventSearchPatient;
        public event EventHandler eventShowAddPatientForm;
        public event EventHandler eventShowEditPatientForm;
        public event EventHandler eventDeletePatient;
        
        public event EventHandler eventShowFormNewExam;
        public event EventHandler eventOpenExam;
        public event EventHandler eventDeleteExam;
        public event EventHandler eventExportExam;

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }

        public void manipulateDataGridView()
        {
            dataGridViewPatient.Columns["id"].Visible = false;
            edit.Frozen = true;
            edit.Image = Properties.Resources.icon_32x32_pencil2;
            edit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            delete.Frozen = true;
            delete.Image = Properties.Resources.icon_32x32_delete;
            delete.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

    }
}
