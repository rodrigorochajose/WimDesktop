using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital.Interface
{
    public interface IDrawing
    {
        int id { get; set; }
        int frameId { get; set; }
        GraphicsPath graphicsPath { get; set; }
        Color drawingColor { get; set; }
        float drawingSize { get; set; }
        List<Point> points { get; set; }

        void drawPreview(Graphics g);
        void draw(Graphics g);
        Image generateDrawingImageAndThumb(int frameId, string path, int width, int height);
        IDrawing deepCopy();
    }
}
