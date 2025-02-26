using System.Collections.Generic;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class MultiSensorDialog : Form
    {
        public string selectedSensor;

        public MultiSensorDialog(List<string> sensors)
        {
            InitializeComponent();

            KeyPreview = true;

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    selectSensor();
                }
            };

            buttonConfirm.Click += delegate { selectSensor(); };

            comboBoxSensor.InnerControl.DataSource = sensors;
            ControlBox = false;
        }

        private void selectSensor()
        {
            selectedSensor = comboBoxSensor.InnerControl.SelectedItem.ToString();
            Close();
        }
    }
}
