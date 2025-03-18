using System;

namespace DMMDigital.Interface.IView
{
    public interface IClinicCreationView
    {
        string name { get; set; }
        string email { get; set; }
        string password { get; set; }

        event EventHandler eventSaveClinic;
        event EventHandler eventUpdatePassword;
    }
}
