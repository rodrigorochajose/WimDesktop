using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital.Views
{
    public interface IManipulateTemplateView
    {
        string templateName { get; set; }
        IList<Frame> framesList { get; }

        event EventHandler eventSaveTemplate;
    }
}
