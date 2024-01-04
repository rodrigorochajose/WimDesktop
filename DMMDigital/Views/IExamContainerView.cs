using DMMDigital.Models;
using System;
using System.Collections.Generic;

namespace DMMDigital.Views
{
    public interface IExamContainerView
    {
        int patientId { get; set; }
        PatientModel patient { get; set; }
        List<int> openExamsId { get; set; }

        event EventHandler eventGetPatient;

        void addNewPage(IExamView examView);
    }
}
