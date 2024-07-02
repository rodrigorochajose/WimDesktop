using Emgu.CV.CvEnum;
using System;

namespace DMMDigital.Interface.IView
{
    public interface IConfigView
    {
        string sensorPath { get; set; }
        string imagePath { get; set; }
        string drawingColor { get; set; }
        int drawingSize { get; set; }
        string textColor { get; set; }
        int textSize { get; set; }
        string rulerColor { get; set; }
        float gamma { get; set; }
        float edge { get; set; }
        float noise { get; set; }

        event EventHandler loadConfigs;
        event EventHandler saveConfigs;

    }
}
