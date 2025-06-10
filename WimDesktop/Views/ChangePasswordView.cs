using System;
using System.Windows.Forms;
using WimDesktop.Interface.IView;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class ChangePasswordView : Form, IClinicChangePasswordView
    {
        public string email { get; set; }

        public string currentPassword
        {
            get { return roundedTextBoxPassword.Texts; }
            set { roundedTextBoxPassword.Texts = value; }
        }

        public string newPassword
        {
            get { return roundedTextBoxNewPassword.Texts; }
            set { roundedTextBoxNewPassword.Texts = value; }
        }

        public event EventHandler eventChangePassword;

        public ChangePasswordView(string email)
        {
            InitializeComponent();

            this.email = email;

            associateEvents();
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                } 
                else if (e.KeyChar == (char)Keys.Enter)
                {
                    changePassword();
                }
            };

            roundedTextBoxConfirmNewPassword.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    changePassword();
                }
            };

            roundedButtonConfirm.Click += delegate { changePassword(); };

            roundedButtonCancel.Click += delegate { Close(); };
        }

        private void changePassword()
        {
            if (newPassword != roundedTextBoxConfirmNewPassword.Texts)
            {
                MessageBox.Show(Resources.messagePasswordNotMatch);
                return;
            }

            eventChangePassword?.Invoke(this, EventArgs.Empty);

            Close();
        }
    }
}
