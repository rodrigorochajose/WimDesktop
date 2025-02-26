using DMMDigital.Interface.IView;
using DMMDigital.Presenters;
using DMMDigital.Properties;
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

        public event EventHandler eventSearchPatient;
        public event EventHandler eventShowAddPatientForm;
        public event EventHandler eventShowEditPatientForm;
        public event EventHandler eventDeletePatient;

        public PatientView()
        {
            InitializeComponent();

            associateEvents();
        }

        private void associateEvents()
        {
            KeyPress += (sender, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            Load += (sender, e) =>
            {
                dataGridViewPatient.SelectionChanged += (s, ev) =>
                {
                    if (dataGridViewPatient.SelectedRows.Count > 0)
                    {
                        selectedPatientId = int.Parse(dataGridViewPatient.CurrentRow.Cells["columnPatientId"].Value.ToString());
                    }
                };
            };

            textBoxSearchPatient.InnerTextBox.KeyDown += (s, e) =>
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

            buttonSearchPatient.Click += delegate 
            { 
                eventSearchPatient?.Invoke(this, EventArgs.Empty); 
            };

            buttonNewPatient.Click += delegate 
            { 
                eventShowAddPatientForm?.Invoke(this, EventArgs.Empty); 
            };
        }

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }

        private void buttonPatientExamsClick(object sender, EventArgs e)
        {
            if (selectedPatientId == 0)
            {
                MessageBox.Show(Resources.messagePatientNotSelected);
                return;
            }

            new PatientExamPresenter(new PatientExamView(), selectedPatientId, "newContainer");
        }
    }
}
