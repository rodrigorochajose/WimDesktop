using WimDesktop.Presenters;
using System;
using System.Windows.Forms;

namespace WimDesktop.Views
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

            roundedTextBoxPath.Texts = path;
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
                new MigrationDatabasePresenter(new MigrationDatabaseView(software, path), path);

                Close();
            };

            buttonCancel.Click += delegate
            {
                Close();
            };
        }
    }
}
