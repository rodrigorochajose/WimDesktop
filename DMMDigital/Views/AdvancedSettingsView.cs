using DMMDigital.Interface.IView;
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

        public AdvancedSettingsView(string sensorPath, string examPath)
        {
            InitializeComponent();

            this.sensorPath = sensorPath;
            this.examPath = examPath;

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

    }
}
