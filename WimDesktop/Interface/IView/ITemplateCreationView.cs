using System;
using System.Collections.Generic;
using WimDesktop.Components;

namespace WimDesktop.Interface.IView
{
    public interface ITemplateCreationView
    {
        string templateName { get; set; }
        List<FrameTemplate> framesList { get; }

        event EventHandler eventSaveTemplate;
    }
}
