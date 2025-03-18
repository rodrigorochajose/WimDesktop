
using System;

namespace DMMDigital.Interface.IView
{
    public interface ILoginView
    {
        string email { get; set; }
        string password { get; set; }
        bool keepCredentials { get; set; }

        event EventHandler eventLogin;
    }
}
