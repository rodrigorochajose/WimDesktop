using WimDesktop.Models;
using System.Collections.Generic;

namespace WimDesktop.Interface.IRepository
{
    public interface IRulerLengthRepository
    {
        void addRulerLength(List<RulerLengthModel> rulerLengths);
        void deleteRangeRulerLength(List<int> drawingsId);
        List<float> getRulerLengthByDrawing(int drawingId);
    }
}
