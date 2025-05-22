using System;

namespace WimDesktop.Interface.IView
{
    public interface IMenuView
    {
        event EventHandler showPatientView;
        event EventHandler showNewExamView;
        event EventHandler showTemplateView;
        event EventHandler showSettingsView;
    }
}
 