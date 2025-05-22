using WimDesktop.Interface.IView;
using WimDesktop.Properties;
using System;
using System.Windows.Forms;

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
        public event EventHandler eventUpdatePassword;

        private readonly bool recoverPassword;


        public ClinicHandlerView(bool recoverPassword)
        {
            InitializeComponent();

            associateEvents();

            this.recoverPassword = recoverPassword;

            if (recoverPassword)
            {
                Text = Resources.titleEditClinic;
                labelDescription.Text = Resources.textPasswordRecovery;
                labelDescription.Left -= 20;

                labelName.Visible = false;
                roundedTextBoxName.Visible = false;

                labelEmail.Top -= 50;
                roundedTextBoxEmail.Top -= 50;

                labelPassword.Top -= 50;
                roundedTextBoxPassword.Top -= 50;

                labelConfirmPassword.Top -= 50;
                roundedTextBoxConfirmPassword.Top -= 50;

                roundedButtonSignUp.Top -= 50;
                roundedButtonSignUp.Text = Resources.textButtonUpdate;
            }
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

            roundedButtonSignUp.Click += delegate { signUp(); };
        }

        private void signUp()
        {
            if (password != roundedTextBoxConfirmPassword.Texts)
            {
                MessageBox.Show("As senhas não coincidem");
                return;
            }

            if (recoverPassword)
            {
                eventUpdatePassword?.Invoke(this, EventArgs.Empty);
                return;
            }

            eventSaveClinic?.Invoke(this, EventArgs.Empty);
        }
    }
}
