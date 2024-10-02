using DMMDigital.Properties;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class DialogAdvancedSettings : Form
    {
        public DialogAdvancedSettings()
        {
            InitializeComponent();

            textBox.InnerTextBox.PasswordChar = '*';
            ActiveControl = textBox;

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
            if (textBox.Text == "WIMDESKTOPADMIN")
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
