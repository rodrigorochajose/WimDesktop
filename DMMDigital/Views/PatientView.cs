using DMMDigital.Interface.IView;
using DMMDigital.Presenters;
using DMMDigital.Properties;
using System;
using System.Drawing;
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
        public string columnNameToOrder { get; set; }
        public bool isAsceding { get; set; } = false;

        public bool checkBoxFromState
        {
            get { return checkBoxFrom.Checked; }
            set { checkBoxFrom.Checked = value; }
        }

        public DateTime dateFrom
        {
            get { return dateTimePickerFrom.Value; }
            set { dateTimePickerFrom.Value = value; }
        }

        public bool checkBoxToState
        {
            get { return checkBoxTo.Checked; }
            set { checkBoxTo.Checked = value; }
        }

        public DateTime dateTo
        {
            get { return dateTimePickerTo.Value; }
            set { dateTimePickerTo.Value = value; }
        }

        public event EventHandler eventSearchPatient;
        public event EventHandler eventShowAddPatientForm;
        public event EventHandler eventOpenAllExams;
        public event EventHandler eventOrderDataGridView;

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

            textBoxSearchPatient.InnerTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    eventSearchPatient?.Invoke(this, EventArgs.Empty);
            };
        }

        private void patientViewLoad(object sender, EventArgs e)
        {
            dataGridViewPatient.SelectionChanged += (s, ev) =>
            {
                if (dataGridViewPatient.SelectedRows.Count > 0)
                {
                    selectedPatientId = int.Parse(dataGridViewPatient.CurrentRow.Cells["columnPatientId"].Value.ToString());
                }
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

            Hide();
            
            new PatientExamPresenter(new PatientExamView(), selectedPatientId, "newContainer");
            
            if (!IsDisposed)
            {
                Show();
            }
        }

        private void buttonOpenExamsClick(object sender, EventArgs e)
        {
            eventOpenAllExams?.Invoke(this, EventArgs.Empty);
        }

        private void buttonNewPatientClick(object sender, EventArgs e)
        {
            eventShowAddPatientForm?.Invoke(this, EventArgs.Empty);
        }

        private void buttonSearchPatientClick(object sender, EventArgs e)
        {
            eventSearchPatient?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridViewPatientColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            columnNameToOrder = dataGridViewPatient.Columns[e.ColumnIndex].Name;

            eventOrderDataGridView?.Invoke(sender, EventArgs.Empty);
        }

        private void checkBoxFromCheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.Enabled = checkBoxFrom.Checked;

            if (checkBoxFrom.Checked)
            {
                dateTimePickerFrom.TextColor = Color.Gray;
            }
            else
            {
                dateTimePickerFrom.TextColor = Color.Silver;
            }
        }

        private void checkBoxToCheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.Enabled = checkBoxTo.Checked;

            if (checkBoxTo.Checked)
            {
                dateTimePickerTo.TextColor = Color.Gray;
            }
            else
            {
                dateTimePickerTo.TextColor = Color.Silver;
            }
        }
    }

    public class PatientModelDGV
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime? lastChange { get; set; }
    }
}
