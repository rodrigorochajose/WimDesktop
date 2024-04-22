using System;
using System.Collections.Generic;
using DMMDigital.Components;
using DMMDigital.Models;

namespace DMMDigital.Views
{
    public interface IExportExamView
    {
        string patientName { get; set; }
        string pathImages { get; set; }
        string pathToExport { get; set; }
        List<Frame> framesToExport { get; set; }
        List<ExamImageDrawingModel> examImageDrawings { get; set; }
    }
}
