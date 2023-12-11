using System.Collections.Generic;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public interface IChooseFramesToCompare
    {
        List<Frame> framesToSelect { get; set; }
        List<Frame> selectedFrames { get; set; }

    }
}
