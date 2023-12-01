using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Forms
{
    public partial class ConfigView : Form, IConfigView
    {
        public string imagePath 
        {
            get { return textBoxPath.Text; }
            set { textBoxPath.Text = value; } 
        }

        public string sensorPath
        {
            get { return textBoxSensor.Text; }
            set { textBoxSensor.Text = value; }
        }

        public event EventHandler loadConfigs;
        public event EventHandler saveConfigs;

        public ConfigView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            Load += delegate { 
                loadConfigs?.Invoke(this, EventArgs.Empty);

            };

            textBoxPath.Click += delegate 
            {
                folderBrowserDialog1.ShowDialog();
                imagePath = folderBrowserDialog1.SelectedPath;
            };

            textBoxSensor.Click += delegate
            {
                folderBrowserDialog1.ShowDialog();
                sensorPath = folderBrowserDialog1.SelectedPath;
            };

            buttonSave.Click += delegate { saveConfigs?.Invoke(this, EventArgs.Empty); };
        }
    }
}
