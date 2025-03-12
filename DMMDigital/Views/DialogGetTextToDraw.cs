using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class DialogGetTextToDraw : Form
    {
        public string textToDraw;

        public DialogGetTextToDraw()
        {
            InitializeComponent();

            ActiveControl = roundedTextBox;

            associateEvents();
        }

        private void associateEvents()
        {
            KeyPreview = true;

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    confirm();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            };

            buttonConfirm.Click += delegate { confirm(); };

            buttonCancel.Click += delegate { Close(); };
        }

        private void confirm()
        {
            textToDraw = roundedTextBox.Texts;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
