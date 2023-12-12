using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Views
{
    public interface IChooseFramesToCompare
    {
        List<Frame> framesToSelect { get; set; }
        List<Frame> selectedFrames { get; set; }
    }
}
