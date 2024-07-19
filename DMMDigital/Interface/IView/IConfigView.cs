using Emgu.CV.CvEnum;
using System;

namespace DMMDigital.Interface.IView
{
    public interface IConfigView
    {
        string sensorPath { get; set; }
        string examPath { get; set; }
        string sensorModel { get; set; }
        string acquireMode { get; set; }
        string drawingColor { get; set; }
        int drawingSize { get; set; }
        string textColor { get; set; }
        int textSize { get; set; }
        string rulerColor { get; set; }
        float brightness { get; set; }
        float contrast { get; set; }
        float reveal { get; set; }
        float smartSharpen { get; set; }

        event EventHandler loadConfigs;
        event EventHandler saveConfigs;
    }
}
