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

            KeyPreview = true;

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    setRulerValue();
                }
            };

            buttonConfirm.Click += delegate
            {
                setRulerValue();
            };

            label.Text = $"Digite o valor de {lineLength:0.00} pixels em milímetros";
        }

        private void setRulerValue()
        {
            rulerValue = (double)numericUpDown.InnerNumericUpDown.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
