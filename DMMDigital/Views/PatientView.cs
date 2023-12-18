using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class PatientView : Form, IPatientView
    {

        public string searchedValue 
        {
            get { return textBoxSearchPatient.Text; }
            set { textBoxSearchPatient.Text = value; }
        }
        public int selectedPatientId { get; set; }
        public int selectedExamId { get; set; }

        public event EventHandler eventSearchPatient;
        public event EventHandler eventShowAddPatientForm;
        public event EventHandler eventShowEditPatientForm;
        public event EventHandler eventDeletePatient;
        
        public event EventHandler eventShowFormNewExam;
        public event EventHandler eventGetPatientExams;
        public event EventHandler eventOpenExam;
        public event EventHandler eventDeleteExam;
        public event EventHandler eventExportExam;

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }

        public void setExamList(BindingSource examList)
        {
            dataGridViewExam.DataSource = examList;
        }

        public void manipulatePatientDataGridView()
        {
            dataGridViewPatient.Columns["id"].Visible = false;
            edit.Frozen = true;
            edit.Image = Properties.Resources.icon_32x32_pencil2;
            edit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            delete.Frozen = true;
            delete.Image = Properties.Resources.icon_32x32_delete;
            delete.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        public void manipulateExamDataGridView()
        {
            dataGridViewExam.Columns["id"].Visible = false;
            dataGridViewExam.Columns["templateID"].Visible = false;

            dataGridViewExam.Columns[2].HeaderText = "Nome da Sessão";
            dataGridViewExam.Columns[2].Width = 197;

            dataGridViewExam.Columns[3].HeaderText = "Data de Nascimento";
            dataGridViewExam.Columns[3].Width = 130;

            dataGridViewExam.Columns[4].HeaderText = "Template";
            dataGridViewExam.Columns[4].Width = 197;
        }

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

            dataGridViewExam.SelectionChanged += (s, e) =>
            {
                if (dataGridViewExam.SelectedCells.Count > 0)
                {
                    int selectedRowIndex = dataGridViewExam.SelectedCells[0].RowIndex;
                    selectedExamId = int.Parse(dataGridViewExam.Rows[selectedRowIndex].Cells[0].Value.ToString());
                }
            };

            buttonSearchPatient.Click += delegate { eventSearchPatient?.Invoke(this, EventArgs.Empty); };

            buttonNewPatient.Click += delegate { eventShowAddPatientForm?.Invoke(this, EventArgs.Empty); };

            buttonNewExam.Click += delegate { eventShowFormNewExam?.Invoke(this, EventArgs.Empty); };

            buttonOpenExam.Click += delegate {
                if (selectedExamId == 0)
                {
                    MessageBox.Show("Nenhum Exame foi selecionado!");
                } 
                else
                {
                    eventOpenExam?.Invoke(this, EventArgs.Empty); 
                }
            };

            buttonDeleteExam.Click += delegate { eventDeleteExam?.Invoke(this, EventArgs.Empty); };

            buttonExportExam.Click += delegate { eventExportExam?.Invoke(this, EventArgs.Empty); };
        }

        private void patientViewLoad(object sender, EventArgs e)
        {
            dataGridViewPatient.CurrentCellChanged += (s, ev) =>
            {
                selectedPatientId = int.Parse(dataGridViewPatient.Rows[0].Cells["id"].Value.ToString());
                eventGetPatientExams?.Invoke(sender, EventArgs.Empty);
            };

        }
    }
}
