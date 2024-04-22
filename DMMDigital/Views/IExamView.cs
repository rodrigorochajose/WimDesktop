using DMMDigital.Models;
using System;
using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Views
{
    public interface IExamView
    {
        int examId { get; set; }
        string sessionName { get; set; }
        PatientModel patient { get; set; }
        int templateId { get; set; }
        string examPath { get; set; }
        Frame selectedFrame { get; set; }
        List<ExamImageModel> examImages { get; set; }
        List<TemplateFrameModel> templateFrames { get; set; }
        List<ExamImageDrawingModel> examImageDrawings { get; set; }
        bool detectorConnected { get; set; }

        event EventHandler eventSaveExam;
        event EventHandler eventSaveExamImage;
        event EventHandler eventSaveExamImageDrawing;
        event EventHandler eventGetPatient;
        event EventHandler eventSaveAndClose;

        void selectFrame(Frame frameToSelected = null);
        void loadImageOnMainPictureBox();
        bool dialogOverrideCurrentImage();
        void setLabelPatientTemplate(string patient, string template);
    }
}
