using System;
using System.Windows.Forms;
using WimDesktop.Interface.IView;
using WimDesktop.Presenters;

namespace WimDesktop.Views
{
    public partial class ClinicProfileView : Form, IClinicProfileView
    {
        public string name 
        {
            get { return roundedTextBoxName.Texts; }
            set { roundedTextBoxName.Texts = value;} 
        }

        public string email 
        {
            get { return roundedTextBoxEmail.Texts;} 
            set { roundedTextBoxEmail.Texts = value; } 
        }

        public event EventHandler eventGetClinicInfo;

        public ClinicProfileView()
        {
            InitializeComponent();

            Load += delegate 
            {
                eventGetClinicInfo?.Invoke(this, EventArgs.Empty);
            };
        }

        private void roundedButtonConfirmClick(object sender, EventArgs e)
        {
            Close();
        }

        private void roundedButtonEditPasswordClick(object sender, EventArgs e)
        {
            using (ChangePasswordView changePasswordView = new ChangePasswordView(email))
            {
                ChangePasswordPresenter changePasswordPresenter = new ChangePasswordPresenter(changePasswordView);
                changePasswordView.ShowDialog();
            }
        }
    }
}
