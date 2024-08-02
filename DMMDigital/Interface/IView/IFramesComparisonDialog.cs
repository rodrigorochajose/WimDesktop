using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Interface.IView
{
    public interface IFramesComparisonDialog
    {
        List<Frame> frames { get; set; }
        List<Frame> selectedFrames { get; set; }
    }
}
