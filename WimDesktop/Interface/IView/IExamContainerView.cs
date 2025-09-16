using System;
using System.Collections.Generic;
using WimDesktop.Models;
using WimDesktop.Views;

namespace WimDesktop.Interface.IView
{
    public interface IExamContainerView
    {
        int patientId { get; set; }
        List<ExamModel> patientExams { get; set; }
        ExamView selectedExamView { get; set; }
        bool twainInitialized { get; set; }
        bool sensorConnected { get; set; }

        event EventHandler eventConnectSensor;
        event EventHandler eventDestroySensor;
        event EventHandler eventSetSensorInfo;
        event EventHandler eventOpenTwain;
        event EventHandler eventInitializeTwain;
        event EventHandler eventCloseTwain;

        void loadDataAndShow();
        void createExamPage(IExamView examView);
    }
}
