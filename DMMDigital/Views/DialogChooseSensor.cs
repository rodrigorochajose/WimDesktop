using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class DialogChooseSensor : Form
    {

        public string selectedSensor;

        public DialogChooseSensor(List<string> sensors)
        {
            InitializeComponent();

            comboBoxSensor.DataSource = sensors;
            ControlBox = false;
        }

        private void buttonConfirmClick(object sender, EventArgs e)
        {
            selectedSensor = comboBoxSensor.SelectedItem.ToString();
            Close();
        }
    }
}
