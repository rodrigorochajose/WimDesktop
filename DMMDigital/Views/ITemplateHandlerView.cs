using System;
using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Views
{
    public interface ITemplateHandlerView
    {
        string templateName { get; set; }
        IList<Frame> framesList { get; }

        event EventHandler eventSaveTemplate;
    }
}
