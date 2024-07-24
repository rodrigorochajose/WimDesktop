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

            KeyPreview = true;

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    selectSensor();
                }
            };

            buttonConfirm.Click += delegate { selectSensor(); };

            comboBoxSensor.InnerComboBox.DataSource = sensors;
            ControlBox = false;
        }

        private void selectSensor()
        {
            selectedSensor = comboBoxSensor.InnerComboBox.SelectedItem.ToString();
            Close();
        }
    }
}
