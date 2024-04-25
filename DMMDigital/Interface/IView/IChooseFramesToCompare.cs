using System.Collections.Generic;
using DMMDigital.Components;

namespace DMMDigital.Interface.IView
{
    public interface IChooseFramesToCompare
    {
        List<Frame> framesToSelect { get; set; }
        List<Frame> selectedFrames { get; set; }
    }
}
