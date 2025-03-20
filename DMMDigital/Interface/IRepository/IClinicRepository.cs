using DMMDigital.Models;

namespace DMMDigital.Interface.IRepository
{
    public interface IClinicRepository
    {
        void addClinic(ClinicModel clinic);
        void updatePassword (string email, string password);
        void update(bool keepConnected, bool automaticLogin);
        ClinicModel getClinic();
        ClinicModel getClinicByEmail(string email);
        bool hasClinic();
        bool keepConnected();
    }
}
