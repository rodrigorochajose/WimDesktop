using System;

namespace DMMDigital.Views
{
    public interface IConfigView
    {
        string imagePath { get; set; }
        string drawingColor { get; set; }
        int drawingSize { get; set; }
        string textColor { get; set; }
        int textSize { get; set; }
        string rulerColor { get; set; }

        event EventHandler loadConfigs;
        event EventHandler saveConfigs;

    }
}
