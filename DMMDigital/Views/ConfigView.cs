using DMMDigital.Interface.IView;
using System;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Windows.Forms;
using TwainDotNet.WinFroms;
using TwainDotNet;
using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Views
{
    public partial class ConfigView : Form, IConfigView
    {
        public string sensorPath
        {
            get { return textBoxSensorPath.Text; }
            set { textBoxSensorPath.Text = value; }
        }

        public string examPath
        {
            get { return textBoxExamPath.Text; }
            set { textBoxExamPath.Text = value; } 
        }

        public string sensorModel 
        {
            get { return comboBoxSensorModel.InnerComboBox.SelectedValue.ToString(); }
            set { comboBoxSensorModel.InnerComboBox.SelectedValue = value; } 
        }

        public string acquireMode
        { 
            get { return comboBoxAcquireMode.InnerComboBox.SelectedItem.ToString(); } 
            set { comboBoxAcquireMode.InnerComboBox.SelectedItem = value; }
        }

        public string drawingColor 
        {
            get { return buttonDrawingColorPicker.BackColor.ToArgb().ToString(); } 
            set { buttonDrawingColorPicker.BackColor = Color.FromArgb(int.Parse(value)); } 
        }

        public int drawingSize
        {
            get { return int.Parse(numericUpDownDrawingSize.InnerNumericUpDown.Value.ToString()); }
            set { numericUpDownDrawingSize.InnerNumericUpDown.Value = value; }
        }

        public string textColor 
        {
            get { return buttonTextColorPicker.BackColor.ToArgb().ToString(); } 
            set { buttonTextColorPicker.BackColor = Color.FromArgb(int.Parse(value)); } 
        }

        public int textSize
        {
            get { return int.Parse(numericUpDownTextSize.InnerNumericUpDown.Value.ToString()); }
            set { numericUpDownTextSize.InnerNumericUpDown.Value = value; }
        }

        public string rulerColor 
        {
            get { return buttonRulerColorPicker.BackColor.ToArgb().ToString(); } 
            set { buttonRulerColorPicker.BackColor = Color.FromArgb(int.Parse(value)); } 
        }

        public float brightness { get; set; }
        public float contrast { get; set; }
        public float reveal { get; set; }
        public float smartSharpen { get; set; }

        public event EventHandler loadConfigs;
        public event EventHandler saveConfigs;

        public ConfigView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            Load += delegate 
            { 
                loadConfigs?.Invoke(this, EventArgs.Empty);
            };

            textBoxSensorPath.Click += delegate
            {
                folderBrowserDialog1.ShowDialog();
                sensorPath = folderBrowserDialog1.SelectedPath;
            };

            textBoxExamPath.Click += delegate 
            {
                folderBrowserDialog1.ShowDialog();
                examPath = folderBrowserDialog1.SelectedPath;
            };

            buttonSave.Click += delegate { saveConfigs?.Invoke(this, EventArgs.Empty); };

            buttonCancel.Click += delegate { Close(); };
        }

        public void setComboBoxSensorModel(List<SensorModel> sensorList)
        {
            comboBoxSensorModel.InnerComboBox.DataSource = sensorList;
            comboBoxSensorModel.InnerComboBox.DisplayMember = "nickname";
            comboBoxSensorModel.InnerComboBox.ValueMember = "name";
        }

        public void setAcquireMode()
        {
            comboBoxAcquireMode.InnerComboBox.DataSource = new List<string> { "TWAIN", "Nativo" };
        }

        private void buttonDrawingColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingColor = colorDialog.Color.ToArgb().ToString();
                buttonDrawingColorPicker.BackColor = colorDialog.Color;
            }
        }

        private void numericUpDownDrawingSizeValueChanged(object sender, EventArgs e)
        {
            drawingSize = (int)numericUpDownDrawingSize.InnerNumericUpDown.Value;
        }

        private void buttonTextColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textColor = colorDialog.Color.ToArgb().ToString();
                buttonTextColorPicker.BackColor = colorDialog.Color;
            }
        }

        private void numericUpDownTextSizeValueChanged(object sender, EventArgs e)
        {
            textSize = (int)numericUpDownTextSize.InnerNumericUpDown.Value;
        }

        private void buttonRulerColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                rulerColor = colorDialog.Color.ToArgb().ToString();
                buttonRulerColorPicker.BackColor = colorDialog.Color;
            }
        }

        private void buttonConfigureFiltersClick(object sender, EventArgs e)
        {
            PostProcessConfig postProcessConfig = new PostProcessConfig(brightness, contrast, reveal, smartSharpen);

            if (postProcessConfig.ShowDialog() == DialogResult.OK)
            {
                brightness = postProcessConfig.brightness;
                contrast = postProcessConfig.contrast;
                reveal = postProcessConfig.reveal;
                smartSharpen = postProcessConfig.smartSharpen;
            }
        }

        private void buttonTwainSourceClick(object sender, EventArgs e)
        {
            Twain twain = new Twain(new WinFormsWindowMessageHook(this));

            twain.SelectSource();
        }
    }
}
