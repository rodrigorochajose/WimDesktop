using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class PatientHandlerView : Form, IPatientHandlerView
    {
        public int patientId { get; set; }

        public string patientName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public DateTime patientBirthDate
        {
            get { return DateTime.Parse(textBoxBirthDate.Text); }
            set { textBoxBirthDate.Text = value.ToString(); }
        }

        public string patientPhone
        {
            get { return textBoxPhone.Text; }
            set { textBoxPhone.Text = value; }
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

        public PatientHandlerView(string action)
        {
            InitializeComponent();
            associateEvents();
            if (action == "add")
            {
                this.action = action;
                Text = "Cadastrar Paciente";
                label1.Text = "Cadastrar Paciente";
                label1.Location = new Point(label1.Location.X - 25, label1.Location.Y);
            }
        }
        private void associateEvents()
        {
            buttonCancel.Click += delegate { Close(); };

            buttonSave.Click += delegate
            {
                if (action == null)
                {
                    eventSaveEditedPatient?.Invoke(this, EventArgs.Empty);
                } 
                else
                {
                    eventAddNewPatient?.Invoke(this, EventArgs.Empty);
                }
            };
        }
    }
}
