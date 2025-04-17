using DMMDigital.Interface.IView;
using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class AdvancedSettingsView : Form, IAdvancedSettingsView
    {
        public string sensorPath
        {
            get { return roundedTextBoxSensorPath.Texts; }
            set { roundedTextBoxSensorPath.Texts = value; }
        }

        public string examPath
        {
            get { return roundedTextBoxExamPath.Texts; }
            set { roundedTextBoxExamPath.Texts = value; }
        }

        public bool waterMark
        {
            get { return checkBoxWaterMark.Checked; }
            set { checkBoxWaterMark.Checked = value; }
        }

        public event EventHandler eventUpdatePatientFiles;
        public event EventHandler eventUpdateWaterMark;

        public AdvancedSettingsView(string sensorPath, string examPath, int waterMark)
        {
            InitializeComponent();

            this.sensorPath = sensorPath;
            this.examPath = examPath;
            this.waterMark = waterMark == 0 ? false : true;

            associateEvents();
        }

        private void associateEvents()
        {
            buttonCancel.Click += delegate { cancel(); };

            buttonOk.Click += delegate { ok(); };

            buttonSensorPath.Click += delegate { selectSensorPath(); };

            buttonExamPath.Click += delegate { selectExamPath(); };

            roundedButtonMigrateCDR.Click += delegate{ openMigrationForm("CDR"); };

            roundedButtonMigrateWimDesktop.Click += delegate{ openMigrationForm("WIM"); };

            checkBoxWaterMark.CheckedChanged += delegate { eventUpdateWaterMark?.Invoke(this, EventArgs.Empty); };
        }

        private void advancedSettingsViewKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                cancel();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ok();
            }
        }

        private void cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void ok()
        {
            DialogResult = DialogResult.OK;
            Close();
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

        private void openMigrationForm(string sw)
        {
            using (Form dialogMigration = new DialogMigration(sw))
            {
                dialogMigration.ShowDialog();
            }
        }

        private void roundedButtonUpdatePatientDataClick(object sender, EventArgs e)
        {
            eventUpdatePatientFiles?.Invoke(this, EventArgs.Empty);
        }
    }
}
