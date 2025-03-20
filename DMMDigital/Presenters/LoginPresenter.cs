using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Properties;
using DMMDigital.Views;
using System;
using System.Windows;

namespace DMMDigital.Presenters
{
    public class LoginPresenter
    {
        public LoginView view { get; }

        private readonly IClinicRepository clinicRepository = new ClinicRepository();
    
        public LoginPresenter(LoginView view)
        {
            this.view = view;

            view.eventLogin += login;
        }

        private void login(object sender, EventArgs e)
        {
            try
            {
                ClinicModel clinic = clinicRepository.getClinicByEmail(view.email);

                if (clinic == null)
                {
                    MessageBox.Show(Resources.messageNotFoundEmail);
                    return;
                }

                if (!BCrypt.Net.BCrypt.Verify(view.password, clinic.password))
                {
                    MessageBox.Show(Resources.messageWrongPassword);
                    return;
                }

                clinicRepository.update(view.keepCredentials, view.automaticLogin);

                view.DialogResult = System.Windows.Forms.DialogResult.OK;
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
