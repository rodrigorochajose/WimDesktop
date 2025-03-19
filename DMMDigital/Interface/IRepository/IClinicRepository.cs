using DMMDigital.Models;

namespace DMMDigital.Interface.IRepository
{
    public interface IClinicRepository
    {
        void addClinic(ClinicModel clinic);
        void updatePassword (string email, string password);
        void updateConnectedInfo(bool keepConnected);
        ClinicModel getClinic();
        ClinicModel getClinicByEmail(string email);
        bool keepConnected();
    }
}
