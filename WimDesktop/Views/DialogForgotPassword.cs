using System;
using System.Windows.Forms;
using WimDesktop.Interface.IView;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class DialogForgotPassword : Form, IDialogForgotPasswordView
    {
        public event EventHandler eventResetPassword;

        public DialogForgotPassword()
        {
            InitializeComponent();
            ActiveControl = roundedTextBox;

            associateEvents();
        }

        public void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    resetPassword();
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    cancel();
                }
            };

            roundedTextBox.KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    resetPassword();
                }
            };

            buttonReset.Click += delegate
            {
                resetPassword();
            };

            buttonCancel.Click += delegate
            {
                cancel();
            };
        }

        private void resetPassword()
        {
            if (roundedTextBox.Texts == "" || roundedTextBox.Texts != "WIMRESET")
            {
                MessageBox.Show(Resources.messageKeyWrong);
                return;
            }

            // futuramente essa funcionalidade vai ser revisada para alterar por email ou alguma outra coisa
            eventResetPassword?.Invoke(this, EventArgs.Empty);
        }

        private void cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
