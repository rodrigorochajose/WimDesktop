using System;
using System.Drawing;
using System.Windows.Forms;
using WimDesktop.Components.Rounded;
using WimDesktop.Interface.IView;
using WimDesktop.Presenters;

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

        public bool automaticLogin
        {
            get { return checkBoxAutomaticLogin.Checked; }
            set { checkBoxAutomaticLogin.Checked = value; }
        }

        public event EventHandler eventLogin;

        public LoginView(string email)
        {
            InitializeComponent();

            this.email = email;

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

            roundedButtonSignIn.Click += delegate
            {
                login();
            };

            roundedTextBoxPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    login();
                }
            };
        }

        private void login()
        {
            eventLogin?.Invoke(this, EventArgs.Empty);
        }

        private void labelForgotPasswordClick(object sender, EventArgs e)
        {
            DialogForgotPassword dialogForgotPassword = new DialogForgotPassword();
            ForgotPasswordPresenter forgotPasswordPresenter = new ForgotPasswordPresenter(dialogForgotPassword);
            dialogForgotPassword.ShowDialog();
        }
    }
}
