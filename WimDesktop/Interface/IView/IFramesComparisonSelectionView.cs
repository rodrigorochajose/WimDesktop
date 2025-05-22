using System.Collections.Generic;
using WimDesktop.Components;

namespace WimDesktop.Interface.IView
{
    public interface IFramesComparisonSelectionView
    {
        List<Frame> frames { get; set; }
        List<Frame> selectedFrames { get; set; }
    }
}
