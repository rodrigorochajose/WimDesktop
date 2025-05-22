using System;
using System.Windows.Forms;
using WimDesktop.Interface.IView;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class ExamPatientSelectionView : Form, IExamPatientSelectionView
    {
        public string searchedValue 
        {
            get { return roundedTextBoxSearchPatient.Texts; }
            set { roundedTextBoxSearchPatient.Texts = value; }
        }

        private int _selectedPatientId;

        public int selectedPatientId 
        {
            get { return _selectedPatientId; } 
            set { _selectedPatientId = value; }
        }

        public event EventHandler eventSearchPatient;
        public event EventHandler eventAddNewPatient;
        public event EventHandler eventSelectPatient;

        public ExamPatientSelectionView()
        {
            InitializeComponent();
            adjustComponent();
            associateEvents();
        }

        private void adjustComponent()
        {
            pictureBoxIcon.Left = (panelHeader.Width - (pictureBoxIcon.Width + labelTitle.Width)) / 2;
            labelTitle.Left = pictureBoxIcon.Left + pictureBoxIcon.Width + 5;
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (selectedPatientId == 0)
                    {
                        MessageBox.Show(Resources.messagePatientNotSelected);
                        return;
                    }

                    eventSelectPatient?.Invoke(this, EventArgs.Empty);
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            roundedTextBoxSearchPatient.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    eventSearchPatient?.Invoke(this, EventArgs.Empty);
            };
        }

        public void dataGridViewHandler()
        {
            dataGridViewPatient.Columns["columnId"].Visible = false;
        }

        public void setPatientList(BindingSource patientList)
        {
            dataGridViewPatient.DataSource = patientList;
        }

        private void examPatientSelectionViewLoad(object sender, EventArgs e)
        {
            dataGridViewPatient.SelectionChanged += (s, ev) =>
            {
                if (dataGridViewPatient.SelectedRows.Count > 0)
                {
                    selectedPatientId = int.Parse(dataGridViewPatient.CurrentRow.Cells["columnId"].Value.ToString());
                }
            };
        }

        private void buttonNewPatientClick(object sender, EventArgs e)
        {
            int rows = dataGridViewPatient.RowCount;
            eventAddNewPatient?.Invoke(this, EventArgs.Empty);

            if (rows != dataGridViewPatient.RowCount)
            {
                int indexLastPatient = dataGridViewPatient.Rows.Count - 1;
                selectedPatientId = int.Parse(dataGridViewPatient.Rows[indexLastPatient].Cells["columnId"].Value.ToString());

                eventSelectPatient?.Invoke(this, EventArgs.Empty);
            }
        }

        private void buttonSearchPatientClick(object sender, EventArgs e)
        {
            eventSearchPatient?.Invoke(this, EventArgs.Empty);
        }
        private void buttonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSelectPatientClick(object sender, EventArgs e)
        {
            if (selectedPatientId == 0)
            {
                MessageBox.Show(Resources.messagePatientNotSelected);
                return;
            }

            eventSelectPatient?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridViewPatientCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedPatientId == 0)
            {
                MessageBox.Show(Resources.messagePatientNotSelected);
                return;
            }

            eventSelectPatient?.Invoke(this, EventArgs.Empty);
        }
    }
}
