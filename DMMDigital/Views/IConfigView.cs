using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital.Views
{
    public interface IConfigView
    {
        string imagePath { get; set; }

        event EventHandler saveImagePath;
        event EventHandler loadImagePath;

    }
}
