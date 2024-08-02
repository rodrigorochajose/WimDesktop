using System;
using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Interface.IView
{
    public interface ITemplateCreationView
    {
        string templateName { get; set; }
        List<FrameTemplate> framesList { get; }

        event EventHandler eventSaveTemplate;
    }
}
