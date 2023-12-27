using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ChoosePatientExamView : Form, IChoosePatientExamView
    {
        public ChoosePatientExamView()
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
            buttonNewPatient.Click += delegate { eventShowAddPatientView?.Invoke(this, EventArgs.Empty); };
            dataGridViewPatient.CellClick += delegate { eventSelectPatient?.Invoke(this, EventArgs.Empty); };
            buttonSelectPatient.Click += delegate {
                if (selectedPatientId == 0)
                {
                    MessageBox.Show("Não há nenhum paciente selecionado!");
                    return; 
                }
                eventSelectPatient?.Invoke(this, EventArgs.Empty); 
            };
            buttonCancelAction.Click += delegate { Close(); };
        }

        public string searchedValue 
        {
            get { return textBoxSearchPatient.Text; }
            set { textBoxSearchPatient.Text = value; }
        }
        public int selectedPatientId 
        {
            get { return dataGridViewPatient.CurrentRow?.Cells["id"].Value != null ? int.Parse(dataGridViewPatient.CurrentRow.Cells["id"].Value.ToString()) : 0; } 
            set { selectedPatientId = value; }
        }

        public event EventHandler eventSearchPatient;
        public event EventHandler eventShowAddPatientView;
        public event EventHandler eventSelectPatient;

        public void manipulateDataGridView()
        {
            dataGridViewPatient.Columns["id"].Visible = false;
        }

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }
    }
}
