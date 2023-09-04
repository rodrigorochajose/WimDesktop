using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Forms
{
    public partial class ConfigView : Form, IConfigView
    {
        public ConfigView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            this.Load += delegate { loadImagePath?.Invoke(this, EventArgs.Empty); };

            textBoxPath.Click += delegate 
            {
                this.folderBrowserDialog1.ShowDialog();
                this.imagePath = folderBrowserDialog1.SelectedPath;
            };

            buttonSave.Click += delegate { saveImagePath?.Invoke(this, EventArgs.Empty); };
        }

        public string imagePath 
        {
            get { return textBoxPath.Text; }
            set { textBoxPath.Text = value; } 
        }

        public event EventHandler loadImagePath;
        public event EventHandler saveImagePath;

    }
}
