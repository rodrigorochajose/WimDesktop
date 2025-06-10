using System;
using System.Windows;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using WimDesktop.Properties;
using WimDesktop.Views;

namespace WimDesktop.Presenters
{
    public class ForgotPasswordPresenter
    {
        public DialogForgotPassword view { get; }
        
        private readonly IClinicRepository clinicRepository = new ClinicRepository();

        public ForgotPasswordPresenter(DialogForgotPassword view)
        {
            this.view = view;

            view.eventResetPassword += resetPassword;
        }

        private void resetPassword(object sender, EventArgs e)
        {
            try
            {
                ClinicModel clinic = clinicRepository.getClinic();

                if (clinic == null)
                {
                    MessageBox.Show(Resources.messageEmailNotFound);
                    return;
                }

                clinicRepository.updatePassword(clinic.email, BCrypt.Net.BCrypt.HashPassword("DENTISTA123"));
                view.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
