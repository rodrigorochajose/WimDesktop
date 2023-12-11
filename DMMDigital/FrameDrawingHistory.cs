using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital
{
    public class FrameDrawingHistory
    {
        public int frameId { get; set; }
        public List<List<IDrawing>> drawingHistory { get; set; }

        public FrameDrawingHistory(int frameId, List<List<IDrawing>> drawingHistory)
        {
            this.frameId = frameId;
            this.drawingHistory = drawingHistory;
        }
    }
}
