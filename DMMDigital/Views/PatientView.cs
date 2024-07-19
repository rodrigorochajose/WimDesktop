using DMMDigital.Interface.IView;
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

        public PatientView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            Load += (sender, e) =>
            {
                dataGridViewPatient.SelectionChanged += (s, ev) =>
                {
                    if (dataGridViewPatient.SelectedRows.Count > 0)
                    {
                        selectedPatientId = int.Parse(dataGridViewPatient.CurrentRow.Cells["columnPatientId"].Value.ToString());
                        eventGetPatientExams?.Invoke(this, EventArgs.Empty);
                    }
                };

                dataGridViewExam.SelectionChanged += delegate
                {
                    if (dataGridViewExam.SelectedRows.Count > 0)
                    {
                        selectedExamId = int.Parse(dataGridViewExam.Rows[dataGridViewExam.SelectedCells[0].RowIndex].Cells["columnExamId"].Value.ToString());
                    }
                };
            };

            textBoxSearchPatient.innerTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    eventSearchPatient?.Invoke(this, EventArgs.Empty);
            };

            dataGridViewPatient.CellContentClick += (s, e) =>
            {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 0)
                    {
                        eventShowEditPatientForm?.Invoke(this, EventArgs.Empty);
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        eventDeletePatient?.Invoke(this, EventArgs.Empty);

                        dataGridViewPatient.Rows[0].Selected = true;
                    }
                }
            };

            dataGridViewExam.CellClick += (s, e) =>
            {
                if (e.ColumnIndex == 0)
                {
                    if(selectedExamId == 0)
                    {
                        MessageBox.Show("Nenhum Exame foi selecionado!");
                        return;
                    }

                    DialogResult confirmacao = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir Exame", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (DialogResult.Yes.Equals(confirmacao))
                    {
                        int selectedRowIndex = dataGridViewExam.SelectedCells[0].RowIndex;

                        string selectedExamSessionName = dataGridViewExam.Rows[selectedRowIndex].Cells[3].Value.ToString();
                        DateTime selectedExamDate = DateTime.Parse(dataGridViewExam.Rows[selectedRowIndex].Cells[4].Value.ToString());

                        selectedExamPath = $"\\Paciente-{selectedPatientId}\\{selectedExamSessionName}_{selectedExamDate:dd-MM-yyyy}";
                        eventDeleteExam?.Invoke(this, EventArgs.Empty);
                    }
                }
            };

            dataGridViewExam.CellDoubleClick += (s, e) =>
            {
                eventOpenExam?.Invoke(this, EventArgs.Empty);
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
                if (selectedExamId == 0)
                {
                    MessageBox.Show("Nenhum Exame foi selecionado!");
                    return;
                } 
                eventOpenExam?.Invoke(this, EventArgs.Empty); 
            };

            buttonExportExam.Click += delegate {
                if (selectedExamId == 0)
                {
                    MessageBox.Show("Nenhum Exame foi selecionado!");
                    return;
                }
                eventExportExam?.Invoke(this, EventArgs.Empty);
            };
        }

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }

        public void setExamList(BindingSource examList)
        {
            dataGridViewExam.DataSource = examList;
        }
    }
}
