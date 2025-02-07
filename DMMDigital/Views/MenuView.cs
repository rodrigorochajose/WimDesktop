using DMMDigital.Interface.IView;
using System;
using System.IO;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class MenuView : Form, IMenuView
    {
        public MenuView()
        {
            InitializeComponent();
            buttonNewExam.Click += delegate { showNewExamView?.Invoke(this, EventArgs.Empty); };
            buttonPatient.Click += delegate { showPatientView?.Invoke(this, EventArgs.Empty); };
            buttonTemplate.Click += delegate { showTemplateView?.Invoke(this, EventArgs.Empty); };
            buttonSettings.Click += delegate { showSettingsView?.Invoke(this, EventArgs.Empty); };

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
        }

        public event EventHandler showPatientView;
        public event EventHandler showNewExamView;
        public event EventHandler showTemplateView;
        public event EventHandler showSettingsView;

        private void menuViewLoad(object sender, EventArgs e)
        {
            string caminho = @"DMMDigital.exe";
            DateTime data_hora = File.GetLastWriteTime(caminho);
            string versao = "WIM Desktop - Versão " + data_hora.ToShortDateString() + " - " + data_hora.ToShortTimeString();
            this.Text = versao;
        }
    }
}
