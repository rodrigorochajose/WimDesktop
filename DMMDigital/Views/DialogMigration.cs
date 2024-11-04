using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class DialogMigration : Form
    {
        private string path = "";
        private string software = "";

        public DialogMigration(string software)
        {
            InitializeComponent();

            associateEvents();

            this.software = software;

            if (software == "WIM") 
            {
                path = $@"{Environment.GetEnvironmentVariable("USERPROFILE")}\.wimdesktop";
            }
            else
            {
                path = @"C:\images\";
            }

            textBoxPath.Text = path;
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            buttonSelectPath.Click += delegate
            {
                folderBrowserDialog.ShowDialog();
                path = folderBrowserDialog.SelectedPath;
            };

            buttonContinue.Click += delegate
            {
                Visible = false;
                Form migrationDatabaseView = new MigrationDatabaseView(software, path);
                migrationDatabaseView.ShowDialog();
                Close();
            };

            buttonCancel.Click += delegate
            {
                Close();
            };
        }
    }
}
