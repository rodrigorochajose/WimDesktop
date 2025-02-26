using DMMDigital.Interface.IView;
using DMMDigital.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class PatientManagerView : Form, IPatientManagerView
    {
        public int patientId { get; set; }

        public string patientName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
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
            get { return textBoxRecommendation.Text; }
            set { textBoxRecommendation.Text = value; }
        }

        public string patientObservation
        {
            get { return textBoxObservation.Text; }
            set { textBoxObservation.Text = value; }
        }

        public event EventHandler eventAddNewPatient;
        public event EventHandler eventSaveEditedPatient;

        private string action;

        public PatientManagerView(string action)
        {
            InitializeComponent();
            this.action = action;

            adjustComponent();
            associateEvents();
        }

        private void adjustComponent()
        {
            if (action == "edit")
            {
                Text = Resources.titleEditPatient;
                labelTitle.Text = Text;
                labelTitle.Location = new Point(labelTitle.Location.X - 25, labelTitle.Location.Y);
            }

            textBoxBirthDate.InnerMaskedTextBox.Mask = "00/00/0000";
            textBoxBirthDate.InnerMaskedTextBox.ValidatingType = typeof(DateTime);

            textBoxPhone.InnerMaskedTextBox.Mask = "(00) 00000-0000";
            textBoxPhone.InnerMaskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;


            pictureBoxIcon.Left = (Width - (pictureBoxIcon.Width + labelTitle.Width + 10)) / 2;
            labelTitle.Left = pictureBoxIcon.Left + pictureBoxIcon.Width;
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    save();
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
                save();
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

        private void save()
        {
            if (action == "edit")
            {
                eventSaveEditedPatient?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                eventAddNewPatient?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
