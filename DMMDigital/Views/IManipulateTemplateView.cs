using System.Collections.Generic;

namespace DMMDigital.Views
{
    public interface IManipulateTemplateView
    {
        string templateName { get; set; }
        List<Frame> frameList { get; set; }
    }
}
