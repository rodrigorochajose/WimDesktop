using WimDesktop.Interface.IView;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WimDesktop.Views
{
    public partial class PatientView : Form, IPatientView
    {
        public string searchedValue 
        {
            get { return roundedTextBoxSearchPatient.Texts; }
            set { roundedTextBoxSearchPatient.Texts = value; }
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
        public event EventHandler eventNewPatient;
        public event EventHandler eventNewExam;
        public event EventHandler eventShowPatientExams;
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

            roundedTextBoxSearchPatient.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
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
            eventShowPatientExams?.Invoke(this, EventArgs.Empty);
        }

        private void buttonOpenExamsClick(object sender, EventArgs e)
        {
            eventOpenAllExams?.Invoke(this, EventArgs.Empty);
        }

        private void buttonNewPatientClick(object sender, EventArgs e)
        {
            eventNewPatient?.Invoke(this, EventArgs.Empty);
        }

        private void buttonNewExamClick(object sender, EventArgs e)
        {
            eventNewExam?.Invoke(this, EventArgs.Empty);
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
                dateTimePickerFrom.TextColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                dateTimePickerFrom.TextColor = Color.Gray;
            }
        }

        private void checkBoxToCheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerTo.Enabled = checkBoxTo.Checked;

            if (checkBoxTo.Checked)
            {
                dateTimePickerTo.TextColor = Color.FromArgb(64, 64, 64);
            }
            else
            {
                dateTimePickerTo.TextColor = Color.Gray;
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
