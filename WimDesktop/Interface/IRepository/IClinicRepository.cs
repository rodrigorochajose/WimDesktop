using WimDesktop.Models;

namespace WimDesktop.Interface.IRepository
{
    public interface IClinicRepository
    {
        void addClinic(ClinicModel clinic);
        void updatePassword (string email, string password);
        void updateLoginMethod(bool automaticLogin);
        ClinicModel getClinic();
        ClinicModel getClinicByEmail(string email);
    }
}
