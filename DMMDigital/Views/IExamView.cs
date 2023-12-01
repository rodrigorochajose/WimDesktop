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
        List<TemplateFrameModel> templateFrames { get; set; }
        List<ExamImageDrawingModel> examImageDrawings { get; set; }

        event EventHandler eventGetExamPath;
        event EventHandler eventSaveExam;
        event EventHandler eventSaveExamImage;
        event EventHandler eventSaveExamImageDrawing;

        void loadImageOnMainPictureBox();
        bool dialogOverrideCurrentImage();
        void setLabelPatientTemplate(string patient, string template);


    }
}
