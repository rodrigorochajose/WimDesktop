using System;
using System.Drawing;

namespace DMMDigital.Views
{
    public interface IExamView
    {
        string sessionName { get; set; }
        int patientId { get; set; }
        int templateId { get; set; }
        string examPath { get; set; }
        Frame selectedFrame { get; set; }

        event EventHandler eventSaveExam;
        event EventHandler eventGetExamPath;

        void loadImageOnMainPictureBox();
        void deleteCurrentImageToReplace();
        
    }
}
