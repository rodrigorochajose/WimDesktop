using WimDesktop.Properties;
using System.Windows.Forms;

namespace WimDesktop.Views
{
    public partial class DialogRecalibrateRuler : Form
    {
        public double rulerValue;

        public DialogRecalibrateRuler(float lineLength)
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    setRulerValue();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            };

            buttonConfirm.Click += delegate
            {
                setRulerValue();
            };

            label.Text = string.Format(Resources.messageRecalibrateRuler, lineLength.ToString("0.00"));
        }

        private void setRulerValue()
        {
            rulerValue = (double)numericUpDown.InnerNumericUpDown.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
