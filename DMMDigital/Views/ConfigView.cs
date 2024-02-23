using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ConfigView : Form, IConfigView
    {
        public string imagePath 
        {
            get { return textBoxPath.Text; }
            set { textBoxPath.Text = value; } 
        }

        public string drawingColor 
        {
            get { return buttonDrawingColorPicker.BackColor.ToString(); } 
            set { buttonDrawingColorPicker.BackColor = Color.FromName(value); } 
        }

        public int drawingSize
        {
            get { return int.Parse(numericUpDownDrawingSize.Value.ToString()); }
            set { numericUpDownDrawingSize.Value = value; }
        }

        public string textColor 
        {
            get { return buttonTextColorPicker.BackColor.ToString(); } 
            set { buttonTextColorPicker.BackColor = Color.FromName(value); } 
        }

        public int textSize
        {
            get { return int.Parse(numericUpDownTextSize.Value.ToString()); }
            set { numericUpDownTextSize.Value = value; }
        }

        public string rulerColor 
        {
            get { return buttonRulerColorPicker.BackColor.ToString(); } 
            set { buttonRulerColorPicker.BackColor = Color.FromName(value); } 
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

            buttonSave.Click += delegate { saveConfigs?.Invoke(this, EventArgs.Empty); };
        }

        private void buttonDrawingColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingColor = colorDialog.Color.ToString();
                buttonDrawingColorPicker.BackColor = colorDialog.Color;
            }
        }

        private void numericUpDownDrawingSizeValueChanged(object sender, EventArgs e)
        {
            drawingSize = (int)numericUpDownDrawingSize.Value;
        }

        private void buttonTextColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textColor = colorDialog.Color.ToString();
                buttonTextColorPicker.BackColor = colorDialog.Color;
            }
        }

        private void numericUpDownTextSizeValueChanged(object sender, EventArgs e)
        {
            textSize = (int)numericUpDownTextSize.Value;
        }

        private void buttonRulerColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                rulerColor = colorDialog.Color.ToString();
                buttonRulerColorPicker.BackColor = colorDialog.Color;
            }
        }
    }
}
