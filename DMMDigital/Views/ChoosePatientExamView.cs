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

            buttonNewPatient.Click += delegate 
            { 
                eventShowAddPatientView?.Invoke(this, EventArgs.Empty);

                int indexLastPatient = dataGridViewPatient.Rows.Count - 1;
                selectedPatientId = int.Parse(dataGridViewPatient.Rows[indexLastPatient].Cells["id"].Value.ToString());

                eventSelectPatient?.Invoke(this, EventArgs.Empty);
            };

            dataGridViewPatient.SelectionChanged += delegate
            {
                selectedPatientId = int.Parse(dataGridViewPatient.CurrentRow.Cells["id"].Value.ToString());
            };

            dataGridViewPatient.CellDoubleClick += delegate 
            { 
                eventSelectPatient?.Invoke(this, EventArgs.Empty); 
            };

            buttonSelectPatient.Click += delegate 
            {
                eventSelectPatient?.Invoke(this, EventArgs.Empty); 
            };

            buttonCancelAction.Click += delegate { Close(); };
        }

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
    }
}
