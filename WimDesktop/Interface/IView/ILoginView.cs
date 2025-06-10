
using System;

namespace WimDesktop.Interface.IView
{
    public interface ILoginView
    {
        string email { get; set; }
        string password { get; set; }
        bool automaticLogin { get; set; }

        event EventHandler eventLogin;
    }
}
