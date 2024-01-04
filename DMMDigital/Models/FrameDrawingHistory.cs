using DMMDigital.Interface;
using System.Collections.Generic;

namespace DMMDigital.Models
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
