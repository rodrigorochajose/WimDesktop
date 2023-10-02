using System;
using System.Drawing;

namespace DMMDigital.Views
{
    public interface IExamView
    {
        string patientName { get; set; }
        string templateName { get; set; }
        string examPath { get; set; }
        Frame selectedFrame { get; set; }

        event EventHandler eventGetExamPath;

        void loadImageOnMainPictureBox();
        void deleteCurrentImageToReplace();
        
    }
}
