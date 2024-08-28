using DMMDigital.Interface.IView;
using System;
using System.Drawing;
using System.Windows.Forms;
using TwainDotNet.WinFroms;
using TwainDotNet;
using DMMDigital.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using DMMDigital.Components.Rounded;
using DMMDigital.Properties;

namespace DMMDigital.Views
{
    public partial class ConfigView : Form, IConfigView
    {
        public string language
        {
            get { return comboBoxLanguage.InnerComboBox.SelectedItem.ToString(); }
            set { comboBoxLanguage.InnerComboBox.SelectedItem = value; }
        }

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

        private Twain twain;
        private bool languageChanged = false;

        public ConfigView()
        {
            InitializeComponent();
            adjustComponent();
            associateEvents();

            twain = new Twain(new WinFormsWindowMessageHook(this));
            textBoxTwainSource.Text = twain.DefaultSourceName;
        }

        private void adjustComponent()
        {
            pictureBoxIcon.Left = (panelHeader.Width - (pictureBoxIcon.Width + labelTitle.Width)) / 2;
            labelTitle.Left = pictureBoxIcon.Left + pictureBoxIcon.Width + 5;
        }

        private void associateEvents()
        {
            Load += delegate 
            {
                loadConfigs?.Invoke(this, EventArgs.Empty);
            };

            comboBoxLanguage.InnerComboBox.SelectionChangeCommitted += delegate
            {
                string culture = comboBoxLanguage.InnerComboBox.SelectedItem.ToString();

                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);

                languageChanged = !languageChanged;
            };

            textBoxTwainSource.InnerTextBox.Click += delegate { selectTwainSource(); };

            buttonSelectTwainSource.Click += delegate { selectTwainSource(); };
            
            textBoxSensorPath.InnerTextBox.Click += delegate { selectSensorPath(); };

            buttonSensorPath.Click += delegate { selectSensorPath(); };

            textBoxExamPath.InnerTextBox.Click += delegate { selectExamPath(); };

            buttonExamPath.Click += delegate { selectExamPath(); };

            buttonSave.Click += delegate
            {
                if (languageChanged)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        applyLocalization(form);
                    }
                }

                saveConfigs?.Invoke(this, EventArgs.Empty);
            };

            buttonCancel.Click += delegate { Close(); };
        }

        public void applyLocalization(Form form)
        {
            ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
            resources.ApplyResources(form, "$this");

            foreach (Control control in form.Controls)
            {
                resources.ApplyResources(control, control.Name);

                if (control is ToolStrip toolStrip)
                {
                    foreach (ToolStripItem item in toolStrip.Items)
                    {
                        Console.WriteLine(item.GetCurrentParent());
                        resources.ApplyResources(item, item.Name);
                    }
                }

                if (control is RoundedPanel p)
                {
                    foreach (Control c in p.Controls)
                    {
                        resources.ApplyResources(c, c.Name);
                    }
                }
            }
        }

        public void setComboBoxSensorModel(List<SensorModel> sensorList)
        {
            comboBoxSensorModel.InnerComboBox.DataSource = sensorList;
            comboBoxSensorModel.InnerComboBox.DisplayMember = "nickname";
            comboBoxSensorModel.InnerComboBox.ValueMember = "name";
        }

        public void setAcquireMode()
        {
            comboBoxAcquireMode.InnerComboBox.DataSource = new List<string> { "TWAIN", Resources.nativeAquireMode };
        }

        public void setLanguages()
        {
            comboBoxLanguage.InnerComboBox.DataSource = new List<string> { "pt-BR", "en-US" };
        }

        private void buttonDrawingColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                drawingColor = colorDialog.Color.ToArgb().ToString();
                buttonDrawingColorPicker.BackColor = colorDialog.Color;
            }
        }

        private void buttonTextColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textColor = colorDialog.Color.ToArgb().ToString();
                buttonTextColorPicker.BackColor = colorDialog.Color;
            }
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
            PostProcessView postProcessConfig = new PostProcessView(brightness, contrast, reveal, smartSharpen);

            if (postProcessConfig.ShowDialog() == DialogResult.OK)
            {
                brightness = postProcessConfig.brightness;
                contrast = postProcessConfig.contrast;
                reveal = postProcessConfig.reveal;
                smartSharpen = postProcessConfig.smartSharpen;
            }
        }

        private void selectTwainSource()
        {
            twain.SelectSource();
            textBoxTwainSource.Text = twain.DefaultSourceName;
        }

        private void selectSensorPath()
        {
            folderBrowserDialog1.ShowDialog();
            sensorPath = folderBrowserDialog1.SelectedPath;
        }

        private void selectExamPath()
        {
            folderBrowserDialog1.ShowDialog();
            examPath = folderBrowserDialog1.SelectedPath;
        }
    }
}
