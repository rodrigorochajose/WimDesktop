using DMMDigital.Interface.IView;
using System;
using System.Drawing;
using System.Windows.Forms;
using DMMDigital.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.ComponentModel;
using DMMDigital.Components.Rounded;
using DMMDigital.Properties;
using System.IO;
using Saraff.Twain;

namespace DMMDigital.Views
{
    public partial class SettingsView : Form, ISettingsView
    {
        public string language
        {
            get { return comboBoxLanguage.InnerControl.SelectedItem.ToString(); }
            set { comboBoxLanguage.InnerControl.SelectedItem = value; }
        }

        public string sensorPath { get; set; }

        public string examPath { get; set; }

        public string sensorModel 
        {
            get { return comboBoxSensorModel.InnerControl.SelectedValue.ToString(); }
            set { comboBoxSensorModel.InnerControl.SelectedValue = value; } 
        }

        public string acquireMode
        {
            get { return comboBoxAcquireMode.InnerControl.SelectedItem.ToString(); }
            set { comboBoxAcquireMode.InnerControl.SelectedItem = value; }
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

        public event EventHandler loadSettings;
        public event EventHandler saveSettings;

        private Twain32 twain = new Twain32();
        private bool languageChanged = false;

        public SettingsView()
        {
            InitializeComponent();
            adjustComponent();
            associateEvents();

            twain.OpenDSM();

            Twain32.Identity currentSource = twain.GetSourceIdentity(twain.SourceIndex);
            roundedTextBoxTwainSource.PlaceholderText = currentSource.Name;
        }

        private void adjustComponent()
        {
            pictureBoxIcon.Left = (panelHeader.Width - (pictureBoxIcon.Width + labelTitle.Width)) / 2;
            labelTitle.Left = pictureBoxIcon.Left + pictureBoxIcon.Width + 5;
        }

        private void associateEvents()
        {
            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }

                if (e.Shift && e.KeyCode == Keys.Home)
                {
                    using (DialogAdvancedSettings dialogAdvancedSettings = new DialogAdvancedSettings())
                    {
                        if (dialogAdvancedSettings.ShowDialog() == DialogResult.OK)
                        {
                            IAdvancedSettingsView advancedSettingsView = new AdvancedSettingsView(sensorPath, examPath);

                            if ((advancedSettingsView as Form).ShowDialog() == DialogResult.OK)
                            {
                                sensorPath = advancedSettingsView.sensorPath;
                                examPath = advancedSettingsView.examPath;
                            }
                        }
                    }
                }
            };

            Load += delegate 
            {
                loadSettings?.Invoke(this, EventArgs.Empty);
            };

            comboBoxLanguage.InnerControl.SelectionChangeCommitted += delegate
            {
                string culture = comboBoxLanguage.InnerControl.SelectedItem.ToString();

                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);

                languageChanged = !languageChanged;
            };

            roundedTextBoxTwainSource.Click += delegate 
            {
                selectTwainSource(); 
            };

            buttonSelectTwainSource.Click += delegate 
            { 
                selectTwainSource(); 
            };

            buttonSave.Click += delegate
            {
                if (languageChanged)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        applyLocalization(form);
                    }
                }

                saveSettings?.Invoke(this, EventArgs.Empty);
            };

            buttonCancel.Click += delegate 
            { 
                Close(); 
            };
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
            comboBoxSensorModel.InnerControl.DataSource = sensorList;
            comboBoxSensorModel.InnerControl.DisplayMember = "nickname";
            comboBoxSensorModel.InnerControl.ValueMember = "name";
        }

        public void setAcquireMode()
        {
            comboBoxAcquireMode.InnerControl.DataSource = new List<string> { "TWAIN", Resources.nativeAquireMode };
        }

        public void setLanguages()
        {
            comboBoxLanguage.InnerControl.DataSource = new List<string> { "pt-BR", "en-US" };
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

            var currentSource = twain.GetSourceIdentity(twain.SourceIndex);
            roundedTextBoxTwainSource.PlaceholderText = currentSource.Name;
        }

        private void buttonEmptyAllRecycleBinClick(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(Resources.messageConfirmEmptyAllRecycleBin, Resources.titleEmptyRecycleBin, MessageBoxButtons.YesNo);

            if (res.Equals(DialogResult.No))
            {
                return;
            }

            string[] patientDirectories = Directory.GetDirectories(examPath);

            foreach (string patientDirectory in patientDirectories)
            {
                string[] examsDirectories = Directory.GetDirectories(patientDirectory);

                foreach(string examDirectory in examsDirectories)
                {
                    string recyclePath = Path.Combine(examDirectory, "recycle");

                    if (Directory.Exists(recyclePath))
                    {
                        string[] imagesInRecycleBin = Directory.GetFiles(recyclePath);

                        foreach(string file in imagesInRecycleBin)
                        {
                            File.Delete(file);
                        }
                    }
                }
            }

            MessageBox.Show(Resources.messageEmptyAllRecycleBinSuccess);
        }
    }
}
