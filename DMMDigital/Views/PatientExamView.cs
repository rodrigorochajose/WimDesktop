using System;
using System.Windows.Forms;
using DMMDigital.Interface.IView;

namespace DMMDigital.Views
{
    public partial class PatientExamView : Form, IPatientExamView
    {
        public string searchedValue 
        {
            get { return textBoxSearchPatient.Text; }
            set { textBoxSearchPatient.Text = value; }
        }

        private int _selectedPatientId;

        public int selectedPatientId 
        {
            get { return _selectedPatientId; } 
            set { _selectedPatientId = value; }
        }

        public event EventHandler eventSearchPatient;
        public event EventHandler eventNewPatient;
        public event EventHandler eventSelectPatient;

        public void dataGridViewHandler()
        {
            dataGridViewPatient.Columns["columnId"].Visible = false;
        }

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }

        public PatientExamView()
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
                        selectedPatientId = int.Parse(dataGridViewPatient.CurrentRow.Cells["columnId"].Value.ToString());
                    }
                };
            };

            textBoxSearchPatient.InnerTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    eventSearchPatient?.Invoke(this, EventArgs.Empty);
            };

            buttonSearchPatient.Click += delegate { eventSearchPatient?.Invoke(this, EventArgs.Empty); };

            buttonNewPatient.Click += delegate 
            {
                int rows = dataGridViewPatient.RowCount;
                eventNewPatient?.Invoke(this, EventArgs.Empty);

                if (rows != dataGridViewPatient.RowCount)
                {
                    int indexLastPatient = dataGridViewPatient.Rows.Count - 1;
                    selectedPatientId = int.Parse(dataGridViewPatient.Rows[indexLastPatient].Cells["columnId"].Value.ToString());

                    eventSelectPatient?.Invoke(this, EventArgs.Empty);
                }

            };

            dataGridViewPatient.CellDoubleClick += delegate 
            {
                if (selectedPatientId == 0)
                {
                    MessageBox.Show("Nenhum Paciente foi selecionado!");
                    return;
                }

                eventSelectPatient?.Invoke(this, EventArgs.Empty); 
            };

            buttonSelectPatient.Click += delegate 
            {
                if (selectedPatientId == 0)
                {
                    MessageBox.Show("Nenhum Paciente foi selecionado!");
                    return;
                }

                eventSelectPatient?.Invoke(this, EventArgs.Empty);
            };

            buttonCancel.Click += delegate 
            {
                DialogResult = DialogResult.Cancel;
                Close(); 
            };
        }
    }
}
