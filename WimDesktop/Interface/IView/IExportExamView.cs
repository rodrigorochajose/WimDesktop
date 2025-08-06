using System;
using System.Collections.Generic;
using WimDesktop.Components;
using WimDesktop.Models;

namespace WimDesktop.Interface.IView
{
    public interface IExportExamView
    {
        string patientName { get; set; }
        string pathImages { get; set; }
        string pathToExport { get; set; }

        bool waterMark { get; set; }
        List<Frame> framesToExport { get; set; }

        event EventHandler eventSaveExportPath;
        event EventHandler eventGetExportPath;
    }
}
