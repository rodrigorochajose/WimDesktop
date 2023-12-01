using System;

namespace DMMDigital.Views
{
    public interface IConfigView
    {
        string imagePath { get; set; }
        string sensorPath { get; set; }

        event EventHandler loadConfigs;
        event EventHandler saveConfigs;

    }
}
