using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Views
{
    public interface IExportExamView
    {
        string patientName { get; set; }
        string pathImages { get; set; }
        string pathToExport { get; set; }
        List<Frame> framesToExport { get; set; }

    }
}
