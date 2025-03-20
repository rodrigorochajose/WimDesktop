using DMMDigital.Interface.IView;
using DMMDigital.Properties;
using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class PatientCreationView : Form, IPatientCreationView
    {
        public int patientId { get; set; }

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

        public event EventHandler eventAddNewPatient;

        public PatientCreationView()
        {
            InitializeComponent();

            adjustComponent();
            associateEvents();
        }

        private void adjustComponent()
        {
            textBoxBirthDate.InnerMaskedTextBox.Mask = "00/00/0000";
            textBoxBirthDate.InnerMaskedTextBox.ValidatingType = typeof(DateTime);

            textBoxPhone.InnerMaskedTextBox.Mask = "(00) 00000-0000";
            textBoxPhone.InnerMaskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            pictureBoxIcon.Left = (Width - (pictureBoxIcon.Width + labelTitle.Width + 10)) / 2;
            labelTitle.Left = pictureBoxIcon.Left + pictureBoxIcon.Width;

            roundedTextBoxObservation.Size = new System.Drawing.Size(302, 102);
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    eventAddNewPatient?.Invoke(this, EventArgs.Empty);
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    DialogResult res = MessageBox.Show(Resources.messageExitWithoutSave, Text, MessageBoxButtons.YesNo);

                    if (res.Equals(DialogResult.Yes))
                    {
                        Close();
                    }
                }
            };

            buttonSave.Click += delegate
            {
                eventAddNewPatient?.Invoke(this, EventArgs.Empty);
            };

            textBoxBirthDate.InnerMaskedTextBox.KeyPress += (s, e) =>
            {
                if (char.IsDigit(e.KeyChar))
                {
                    if (s is MaskedTextBox mtb)
                    {
                        int selectionStart = mtb.SelectionStart;
                        if (selectionStart == 2 || selectionStart == 5)
                        {
                            mtb.SelectionStart = selectionStart + 1;
                        }
                    }
                }
            };

            textBoxBirthDate.InnerMaskedTextBox.Click += (s, e) =>
            {
                if (s != null)
                {
                    (s as MaskedTextBox).SelectionStart = 0;
                }
            };

            buttonCancel.Click += delegate
            {
                Close();
            };
        }
    }
}
