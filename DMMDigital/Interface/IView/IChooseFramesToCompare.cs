using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Interface.IView
{
    public interface IChooseFramesToCompare
    {
        List<Frame> frames { get; set; }
        List<Frame> selectedFrames { get; set; }
    }
}
