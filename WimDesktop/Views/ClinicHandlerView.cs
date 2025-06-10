using WimDesktop.Interface.IView;
using System;
using System.Windows.Forms;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class ClinicHandlerView : Form, IClinicCreationView
    {
        public string name
        {
            get { return roundedTextBoxName.Texts; }
            set { roundedTextBoxName.Texts = value; }
        }

        public string email
        {
            get { return roundedTextBoxEmail.Texts; }
            set { roundedTextBoxEmail.Texts = value; }
        }

        public string password
        {
            get { return roundedTextBoxPassword.Texts; }
            set { roundedTextBoxPassword.Texts = value; }
        }

        public event EventHandler eventSaveClinic;

        public ClinicHandlerView()
        {
            InitializeComponent();

            associateEvents();
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    signUp();
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            roundedTextBoxConfirmPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    signUp();
                }
            };

            roundedButtonSignUp.Click += delegate { signUp(); };
        }

        private void signUp()
        {
            if (password != roundedTextBoxConfirmPassword.Texts)
            {
                MessageBox.Show(Resources.messagePasswordNotMatch);
                return;
            }

            eventSaveClinic?.Invoke(this, EventArgs.Empty);
        }
    }
}
