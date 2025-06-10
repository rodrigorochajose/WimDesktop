using System;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using WimDesktop.Views;

namespace WimDesktop.Presenters
{
    public class ClinicProfilePresenter
    {
        public ClinicProfileView view { get; }

        private readonly IClinicRepository clinicRepository = new ClinicRepository();

        public ClinicProfilePresenter(ClinicProfileView view)
        {
            this.view = view;

            view.eventGetClinicInfo += getClinicInfo;
        }

        private void getClinicInfo(object sender, EventArgs ev)
        {
            ClinicModel clinic = clinicRepository.getClinic();

            view.name = clinic.name;
            view.email = clinic.email;
        }
    }
}
