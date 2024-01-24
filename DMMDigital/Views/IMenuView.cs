using System;

namespace DMMDigital.Views
{
    public interface IMenuView
    {
        event EventHandler showPatientView;
        event EventHandler showNewExamView;
        event EventHandler showTemplateView;
        event EventHandler showConfigView;
    }
}
 