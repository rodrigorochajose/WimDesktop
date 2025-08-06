using WimDesktop.Interface.IView;
using System;
using System.IO;
using System.Windows.Forms;

namespace WimDesktop.Views
{
    public partial class MenuView : Form, IMenuView
    {
        public event EventHandler showPatientView;
        public event EventHandler showNewExamView;
        public event EventHandler showTemplateView;
        public event EventHandler showSettingsView;
        public event EventHandler showProfileView;
        public event EventHandler eventLogout;

        public MenuView()
        {
            InitializeComponent();
            buttonNewExam.Click += delegate { showNewExamView?.Invoke(this, EventArgs.Empty); };
            buttonPatient.Click += delegate { showPatientView?.Invoke(this, EventArgs.Empty); };
            buttonTemplate.Click += delegate { showTemplateView?.Invoke(this, EventArgs.Empty); };
            buttonSettings.Click += delegate { showSettingsView?.Invoke(this, EventArgs.Empty); };
            roundedButtonProfile.Click += delegate { showProfileView?.Invoke(this, EventArgs.Empty); };

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }

        private void menuViewLoad(object sender, EventArgs e)
        {
            string caminho = @"WimDesktop.exe";
            DateTime data_hora = File.GetLastWriteTime(caminho);
            string versao = $"WIM Desktop - Version 06/08";
            Text = versao;
        }

        private void roundedButtonLogoutClick(object sender, EventArgs e)
        {
            eventLogout?.Invoke(this, EventArgs.Empty);
        }
    }
}
