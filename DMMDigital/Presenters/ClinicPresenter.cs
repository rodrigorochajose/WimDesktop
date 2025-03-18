using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Windows;

namespace DMMDigital.Presenters
{
    public class ClinicPresenter
    {
        public ClinicHandlerView view { get; }

        private readonly IClinicRepository clinicRepository = new ClinicRepository();

        public ClinicPresenter(ClinicHandlerView view)
        {
            this.view = view;

            view.eventSaveClinic += addClinic;
            view.eventUpdatePassword += updateClinicPassword;
        }

        private void addClinic(object sender, EventArgs e)
        {
            try
            {
                ClinicModel newClinic = new ClinicModel
                {
                    name = view.name,
                    email = view.email,
                    password = BCrypt.Net.BCrypt.HashPassword(view.password)
                };

                new Common.ModelDataValidation().Validate(newClinic);
                clinicRepository.addClinic(newClinic);

                view.DialogResult = System.Windows.Forms.DialogResult.OK;
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateClinicPassword(object sender, EventArgs e)
        {
            try
            {
                clinicRepository.updatePassword(view.email, BCrypt.Net.BCrypt.HashPassword(view.password));
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
