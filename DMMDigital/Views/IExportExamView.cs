using System;
using System.Collections.Generic;
using System.Drawing;

namespace DMMDigital.Views
{
    public interface IExportExamView
    {
        string sessionName { get; set; }
        string pathImages { get; set; }
        string pathToExport { get; set; }
        List<Frame> framesToExport { get; set; }

    }
}
