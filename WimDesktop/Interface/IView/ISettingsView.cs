using System;

namespace WimDesktop.Interface.IView
{
    public interface ISettingsView
    {
        string language { get; set; }
        string sensorPath { get; set; }
        string examPath { get; set; }
        string sensorModel { get; set; }
        string acquireMode { get; set; }
        string drawingColor { get; set; }
        int drawingSize { get; set; }
        string textColor { get; set; }
        int textSize { get; set; }
        string rulerColor { get; set; }
        int waterMark { get; set; }
        float brightness { get; set; }
        float contrast { get; set; }
        float reveal { get; set; }
        float smartSharpen { get; set; }

        event EventHandler loadSettings;
        event EventHandler saveSettings;
    }
}
