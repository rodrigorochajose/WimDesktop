using DMMDigital.Views;
using System;
using System.Collections.Generic;

namespace DMMDigital.Interface.IView
{
    public interface IExamContainerView
    {
        int patientId { get; set; }
        List<int> openExamsId { get; set; }
        ExamView selectedExamView { get; set; }

        event EventHandler eventConnectSensor;
        event EventHandler eventDestroySensor;
        event EventHandler eventGetSensorInfo;
        event EventHandler eventOpenTwain;

        void initialize();
        void addNewPage(IExamView examView);
    }
}
