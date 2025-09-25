using System.Windows.Forms;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class DialogOverwriteImage : Form
    {
        public DialogOverwriteImage()
        {
            InitializeComponent();

            Text = Resources.titleOverwriteImage;
            labelOverwrite.Text = Resources.messageImageConfirmOverwrite;

            associateEvents();
        }

        private void associateEvents()
        {
            buttonConfirm.Click += delegate
            {
                DialogResult = DialogResult.Yes;
                Close();
            };

            buttonCancel.Click += delegate
            {
                DialogResult = DialogResult.No;
                Close();
            };
        }
    }
}
