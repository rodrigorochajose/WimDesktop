using System;
using System.Windows;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using WimDesktop.Views;

namespace WimDesktop.Presenters
{
    public class ChangePasswordPresenter
    {
        public ChangePasswordView view { get; }

        private readonly IClinicRepository clinicRepository = new ClinicRepository();

        public ChangePasswordPresenter(ChangePasswordView view)
        {
            this.view = view;

            view.eventChangePassword += changePassword;
        }
        
        private void changePassword(object sender, EventArgs ev)
        {
            ClinicModel clinic = clinicRepository.getClinicByEmail(view.email);

            if (!BCrypt.Net.BCrypt.Verify(view.currentPassword, clinic.password))
            {
                MessageBox.Show("A senha está incorreta");
                return;
            }

            clinicRepository.updatePassword(view.email, BCrypt.Net.BCrypt.HashPassword(view.newPassword));

            view.Close();
        }
    }
}
