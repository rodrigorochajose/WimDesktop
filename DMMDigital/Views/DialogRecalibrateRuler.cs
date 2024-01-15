using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class DialogRecalibrateRuler : Form
    {
        public double rulerValue;

        public DialogRecalibrateRuler()
        {
            InitializeComponent();
        }

        private void buttonConfirmClick(object sender, EventArgs e)
        {
            rulerValue = (double)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
