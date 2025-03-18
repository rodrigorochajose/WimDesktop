using DMMDigital.Models;

namespace DMMDigital.Interface.IRepository
{
    public interface IClinicRepository
    {
        void addClinic(ClinicModel clinic);
        void updatePassword (string email, string password);
        void updateConnectedInfo(bool keepConnected);
        ClinicModel getClinicByEmail(string email);
        bool hasClinic();
        bool keepConnected();
    }
}
