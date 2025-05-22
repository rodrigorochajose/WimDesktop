using System;

namespace WimDesktop.Interface.IView
{
    public interface IAdvancedSettingsView
    {
        string sensorPath { get; set; }
        string examPath { get; set; }

        bool waterMark { get; set; }

        event EventHandler eventUpdatePatientFiles;
        event EventHandler eventUpdateWaterMark;
    }
}
