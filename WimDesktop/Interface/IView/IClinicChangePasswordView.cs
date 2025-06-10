using System;

namespace WimDesktop.Interface.IView
{
    public interface IClinicChangePasswordView
    {
        string email { get; set; }
        string currentPassword { get; set; }
        string newPassword { get; set; }

        event EventHandler eventChangePassword;
    }
}
