using WimDesktop.Models;
using System;
using System.Collections.Generic;
using WimDesktop.Components;

namespace WimDesktop.Interface.IView
{
    public interface IExamView
    {
        ExamModel exam { get; set; }
        int patientId { get; set; }
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
        bool nextFrameSelection { get; set; }
        bool recycleImage { get; set; }

        event EventHandler eventSaveExam;
        event EventHandler eventUpdateExamLastChange;
        event EventHandler eventSaveExamImage;
        event EventHandler eventSaveExamImageDrawing;
        event EventHandler eventCloseSingleExam;
        event EventHandler eventChangeAcquireMode;
        event EventHandler eventAcquireTwain;
        event EventHandler eventCloseTwainScreen;
        event EventHandler eventNewExam;
        event EventHandler eventExportExam;

        void recycleCurrentImage();
        void selectFrame(Frame frameToSelect = null);
        void loadImageOnMainPictureBox();
        bool dialogOverwriteCurrentImage();
        void setLabelPatientTemplate(string patient, string template);
    }
}
