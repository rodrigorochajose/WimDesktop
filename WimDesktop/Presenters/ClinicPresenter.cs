using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using WimDesktop.Views;
using System;
using System.Windows;

namespace WimDesktop.Presenters
{
    public class ClinicPresenter
    {
        public ClinicHandlerView view { get; }

        private readonly IClinicRepository clinicRepository = new ClinicRepository();

        public ClinicPresenter(ClinicHandlerView view)
        {
            this.view = view;

            view.eventSaveClinic += addClinic;
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
    }
}
