using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class DialogRecalibrateRuler : Form
    {
        public double rulerValue;

        public DialogRecalibrateRuler(float lineLength)
        {
            InitializeComponent();

            label.Text = $"Digite o valor de {lineLength:0.00} pixels em milímetros";
        }

        private void buttonConfirmClick(object sender, EventArgs e)
        {
            rulerValue = (double)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
