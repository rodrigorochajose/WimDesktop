using DMMDigital.Interface.IView;
using DMMDigital.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class PatientExamView : Form, IPatientExamView
    {
        public int patientId { get; set; }
        public int selectedExamId { get; set; }
        public int selectedTemplateId { get; set; }
        public string selectedExamPath { get; set; }

        public string patientName
        {
            get { return roundedTextBoxName.Texts; }
            set { roundedTextBoxName.Texts = value; }
        }

        public DateTime patientBirthDate
        {
            get { return DateTime.Parse(textBoxBirthDate.InnerMaskedTextBox.Text); }
            set { textBoxBirthDate.InnerMaskedTextBox.Text = value.ToString(); }
        }

        public string patientPhone
        {
            get { return textBoxPhone.InnerMaskedTextBox.Text; }
            set { textBoxPhone.InnerMaskedTextBox.Text = value; }
        }

        public string patientRecommendation
        {
            get { return roundedTextBoxRecommendation.Texts; }
            set { roundedTextBoxRecommendation.Texts = value; }
        }

        public string patientObservation
        {
            get { return roundedTextBoxObservation.Texts; }
            set { roundedTextBoxObservation.Texts = value; }
        }

        public bool patientHasChanges { get; set; } = false;

        public event EventHandler eventEditPatient;
        public event EventHandler eventDeletePatient;

        public event EventHandler eventShowFormNewExam;
        public event EventHandler eventOpenExam;
        public event EventHandler eventDeleteExam;
        public event EventHandler eventExportExam;
        public event EventHandler eventSwitchTemplate;

        public PatientExamView()
        {
            InitializeComponent();

            textBoxBirthDate.InnerMaskedTextBox.Mask = "00/00/0000";
            textBoxBirthDate.InnerMaskedTextBox.ValidatingType = typeof(DateTime);

            textBoxPhone.InnerMaskedTextBox.Mask = "(00) 00000-0000";
            textBoxPhone.InnerMaskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

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
        }

        public void setExamList(BindingSource examList)
        {
            dataGridViewExam.DataSource = examList;
        }

        private void buttonEditPatientClick(object sender, EventArgs e)
        {
            if (buttonEditPatient.Text == "Editar")
            {
                handleTextBoxes(true);

                buttonEditPatient.Text = "Salvar";
            }
            else
            {
                eventEditPatient?.Invoke(this, EventArgs.Empty);
                patientHasChanges = true;

                handleTextBoxes(false);
                buttonEditPatient.Text = "Editar";
            }
        }

        private void buttonDeletePatientClick(object sender, EventArgs e)
        {
            eventDeletePatient?.Invoke(this, EventArgs.Empty);

            patientHasChanges = true;
        }

        private void handleTextBoxes(bool enable)
        {
            Color color = enable ? Color.FromArgb(64, 64, 64) : Color.Gray;

            roundedTextBoxName.Enabled = enable;
            roundedTextBoxName.ForeColor = color;

            textBoxBirthDate.Enabled = enable;
            textBoxBirthDate.ForeColor = color;

            textBoxPhone.Enabled = enable;
            textBoxPhone.ForeColor = color;

            roundedTextBoxRecommendation.Enabled = enable;
            roundedTextBoxRecommendation.ForeColor = color;

            roundedTextBoxObservation.Enabled = enable;
            roundedTextBoxObservation.ForeColor = color;
        }

        private void buttonNewExamClick(object sender, EventArgs e)
        { 
            if (patientId == 0)
            {
                MessageBox.Show(Resources.messagePatientNotSelected);
                return;
            }
            eventShowFormNewExam?.Invoke(this, EventArgs.Empty);
        }

        private void buttonOpenExamClick(object sender, EventArgs e)
        {
            if (selectedExamId == 0)
            {
                MessageBox.Show(Resources.messageExamNotSelected);
                return;
            }
            eventOpenExam?.Invoke(this, EventArgs.Empty);
        }

        private void buttonExportExamClick(object sender, EventArgs e)
        {
            if (selectedExamId == 0)
            {
                MessageBox.Show(Resources.messageExamNotSelected);
                return;
            }
            eventExportExam?.Invoke(this, EventArgs.Empty);
        }

        private void dataGridViewExamSelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewExam.SelectedRows.Count > 0)
            {
                selectedExamId = int.Parse(dataGridViewExam.Rows[dataGridViewExam.SelectedCells[0].RowIndex].Cells["columnExamId"].Value.ToString());
            }
        }

        private void dataGridViewExamCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                selectedTemplateId = int.Parse(dataGridViewExam.Rows[dataGridViewExam.SelectedCells[0].RowIndex].Cells["columnTemplateId"].Value.ToString());
                eventSwitchTemplate?.Invoke(this, EventArgs.Empty);
            }
            else if (e.ColumnIndex == 1)
            {
                if (selectedExamId == 0)
                {
                    MessageBox.Show(Resources.messageExamNotSelected);
                    return;
                }

                int selectedRowIndex = dataGridViewExam.SelectedCells[0].RowIndex;

                string selectedExamSessionName = dataGridViewExam.Rows[selectedRowIndex].Cells["columnSessionName"].Value.ToString();
                DateTime selectedExamDate = DateTime.Parse(dataGridViewExam.Rows[selectedRowIndex].Cells["columnExamDate"].Value.ToString());

                selectedExamPath = $"\\Paciente-{patientId}\\{selectedExamSessionName}_{selectedExamDate:dd-MM-yyyy-HH-m}";
                eventDeleteExam?.Invoke(this, EventArgs.Empty);
            }
        }

        private void dataGridViewExamCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            eventOpenExam?.Invoke(this, EventArgs.Empty);
        }
    }
}
