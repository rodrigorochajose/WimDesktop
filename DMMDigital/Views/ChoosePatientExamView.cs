using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ChoosePatientExamView : Form, IChoosePatientExamView
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
        public event EventHandler eventShowAddPatientView;
        public event EventHandler eventSelectPatient;

        public void dataGridViewHandler()
        {
            dataGridViewPatient.Columns["id"].Visible = false;
        }

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }

        public ChoosePatientExamView()
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
                        selectedPatientId = int.Parse(dataGridViewPatient.CurrentRow.Cells["id"].Value.ToString());
                    }
                };
            };

            textBoxSearchPatient.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    eventSearchPatient?.Invoke(this, EventArgs.Empty);
            };

            buttonNewPatient.Click += delegate 
            { 
                eventShowAddPatientView?.Invoke(this, EventArgs.Empty);

                int indexLastPatient = dataGridViewPatient.Rows.Count - 1;
                selectedPatientId = int.Parse(dataGridViewPatient.Rows[indexLastPatient].Cells["id"].Value.ToString());

                eventSelectPatient?.Invoke(this, EventArgs.Empty);
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

            buttonCancelAction.Click += delegate { Close(); };
        }
    }
}
