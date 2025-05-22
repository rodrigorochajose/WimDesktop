using WimDesktop.Interface.IView;
using WimDesktop.Presenters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WimDesktop.Views
{
    public partial class LoginView : Form, ILoginView
    {
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

        public bool keepCredentials
        {
            get { return checkBoxKeepCredentials.Checked; }
            set { checkBoxKeepCredentials.Checked = value; }
        }

        public bool automaticLogin
        {
            get { return checkBoxAutomaticLogin.Checked; }
            set { checkBoxAutomaticLogin.Checked = value; }
        }

        public event EventHandler eventLogin;

        public LoginView(string email, bool keepConnected)
        {
            InitializeComponent();

            this.email = email;
            this.keepCredentials = keepConnected;

            if (email != "")
            {
                ActiveControl = roundedTextBoxPassword;
            }

            associateEvents();
        }

        private void associateEvents()
        {
            labelForgotPassword.MouseEnter += delegate
            {
                labelForgotPassword.ForeColor = Color.MediumBlue;

            };

            labelForgotPassword.MouseLeave += delegate
            {
                labelForgotPassword.ForeColor = Color.DodgerBlue;

            };
        }

        private void roundedButtonSignInClick(object sender, EventArgs e)
        {
            eventLogin?.Invoke(this, EventArgs.Empty);
        }

        private void labelForgotPasswordClick(object sender, EventArgs e)
        {
            ClinicHandlerView view = new ClinicHandlerView(true);

            new ClinicPresenter(view);

            view.ShowDialog();
        }
    }
}
