using WimDesktop.Models;
using System;
using System.Collections.Generic;
using WimDesktop.Components;

namespace WimDesktop.Interface.IView
{
    public interface IExamView
    {
        ExamModel exam { get; set; }
        PatientModel patient { get; set; }
        int templateId { get; set; }
        string examPath { get; set; }
        Frame selectedFrame { get; set; }
        List<ExamImageModel> examImages { get; set; }
        List<TemplateFrameModel> templateFrames { get; set; }
        List<ExamImageDrawingModel> examImageDrawings { get; set; }
        SettingsModel settings { get; set; }
        SensorModel sensor { get; set; }
        bool sensorConnected { get; set; }
        string acquireMode { get; set; }
        bool twainAutoTake { get; set; }
        bool recycleImage { get; set; }

        event EventHandler eventSaveExam;
        event EventHandler eventUpdateExamLastChange;
        event EventHandler eventSaveExamImage;
        event EventHandler eventSaveExamImageDrawing;
        event EventHandler eventGetPatient;
        event EventHandler eventCloseSingleExam;
        event EventHandler eventChangeAcquireMode;
        event EventHandler eventAcquireTwain;

        void recycleCurrentImage();
        void selectFrame(Frame frameToSelected = null);
        void loadImageOnMainPictureBox();
        bool dialogOverwriteCurrentImage();
        void setLabelPatientTemplate(string patient, string template);
    }
}
