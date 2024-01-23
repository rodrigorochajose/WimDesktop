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
        public string selectedExamPath { get; set; }

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
            dataGridViewExam.Columns[2].Width = 195;

            dataGridViewExam.Columns[3].HeaderText = "Data de Nascimento";
            dataGridViewExam.Columns[3].Width = 130;

            dataGridViewExam.Columns[4].HeaderText = "Template";
            dataGridViewExam.Columns[4].Width = 195;
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

            buttonSearchPatient.Click += delegate { eventSearchPatient?.Invoke(this, EventArgs.Empty); };

            buttonNewPatient.Click += delegate { eventShowAddPatientForm?.Invoke(this, EventArgs.Empty); };

            buttonNewExam.Click += delegate {
                if (selectedPatientId == 0)
                {
                    MessageBox.Show("Nenhum Paciente foi selecionado!");
                    return;
                }
                eventShowFormNewExam?.Invoke(this, EventArgs.Empty); 
            };

            buttonOpenExam.Click += delegate {
                if (dataGridViewExam.SelectedCells.Count != 0)
                {
                    int selectedRowIndex = dataGridViewExam.SelectedCells[0].RowIndex;
                    selectedExamId = int.Parse(dataGridViewExam.Rows[selectedRowIndex].Cells[0].Value.ToString());

                    if (selectedExamId == 0)
                    {
                        MessageBox.Show("Nenhum Exame foi selecionado!");
                        return;
                    } 
                    eventOpenExam?.Invoke(this, EventArgs.Empty); 
                }
            };

            buttonDeleteExam.Click += delegate {
                if (dataGridViewExam.SelectedCells.Count != 0)
                {
                    DialogResult res = MessageBox.Show("Confirma excluir o exame selecionado?", "Excluir Exame", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        int selectedRowIndex = dataGridViewExam.SelectedCells[0].RowIndex;

                        selectedExamId = int.Parse(dataGridViewExam.Rows[selectedRowIndex].Cells[0].Value.ToString());
                        string selectedExamSessionName = dataGridViewExam.Rows[selectedRowIndex].Cells[2].Value.ToString();
                        DateTime selectedExamDate = DateTime.Parse(dataGridViewExam.Rows[selectedRowIndex].Cells[3].Value.ToString());

                        selectedExamPath = "\\Paciente-" + selectedPatientId + "\\" + selectedExamSessionName + "_" + selectedExamDate.ToString("dd-MM-yyyy");
                        eventDeleteExam?.Invoke(this, EventArgs.Empty);
                    }
                }
            };

            buttonExportExam.Click += delegate {

                int selectedRowIndex = dataGridViewExam.SelectedCells[0].RowIndex;
                selectedExamId = int.Parse(dataGridViewExam.Rows[selectedRowIndex].Cells[0].Value.ToString());

                if (selectedExamId == 0)
                {
                    MessageBox.Show("Nenhum Exame foi selecionado!");
                    return;
                }
                eventExportExam?.Invoke(this, EventArgs.Empty);
            };
        }

        private void patientViewLoad(object sender, EventArgs e)
        {
            dataGridViewPatient.CurrentCellChanged += (s, ev) =>
            {
                if (dataGridViewPatient.SelectedRows.Count > 0)
                {
                    selectedPatientId = int.Parse(dataGridViewPatient.Rows[dataGridViewPatient.SelectedRows[0].Index].Cells["id"].Value.ToString());
                    eventGetPatientExams?.Invoke(sender, EventArgs.Empty);
                }
            };
        }
    }
}
