using System;
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
            buttonConfig.Click += delegate { showConfigView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler showPatientView;
        public event EventHandler showNewExamView;
        public event EventHandler showConfigView;
    }
}
