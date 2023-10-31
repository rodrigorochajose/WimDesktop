using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DMMDigital.Views
{
    public interface IExamView
    {
        int examId { get; set; }
        string sessionName { get; set; }
        int patientId { get; set; }
        int templateId { get; set; }
        string examPath { get; set; }
        Frame selectedFrame { get; set; }
        List<ExamImageModel> examImages { get; set; }

        event EventHandler eventSaveExam;
        event EventHandler eventExamImageSaveChanges;
        event EventHandler eventGetExamPath;

        void loadImageOnMainPictureBox();
        bool dialogOverrideCurrentImage();
        
    }
}
