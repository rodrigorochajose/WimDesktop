using WimDesktop.Properties;
using System.Windows.Forms;

namespace WimDesktop.Views
{
    public partial class DialogAdvancedSettings : Form
    {
        public DialogAdvancedSettings()
        {
            InitializeComponent();

            roundedTextBox.PasswordChar = true;
            ActiveControl = roundedTextBox;

            associateEvents();
        }

        public void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    unlock();
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    cancel();
                }
            };

            buttonUnlock.Click += delegate
            {
                unlock();
            };

            buttonCancel.Click += delegate
            {
                cancel();
            };
        }

        private void unlock()
        {
            if (roundedTextBox.Texts == "WIMDESKTOPADMIN")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(Resources.messageWrongPassword);
            }
        }

        private void cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
