using System;

namespace WimDesktop.Interface.IView
{
    public interface IClinicProfileView
    {
        string name { get; set; }
        string email { get; set; }

        event EventHandler eventGetClinicInfo;
    }
}
