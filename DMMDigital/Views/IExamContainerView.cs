using DMMDigital.Models;
using System;
using System.Collections.Generic;

namespace DMMDigital.Views
{
    public interface IExamContainerView
    {
        int patientId { get; set; }
        List<int> openExamsId { get; set; }

        event EventHandler eventDestroyDetector;

        void addNewPage(IExamView examView);
    }
}
