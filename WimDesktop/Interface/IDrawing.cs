using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WimDesktop.Interface
{
    public interface IDrawing
    {
        int id { get; set; }
        int examImageId { get; set; }
        GraphicsPath graphicsPath { get; set; }
        Color drawingColor { get; set; }
        float drawingSize { get; set; }
        List<Point> points { get; set; }

        void drawPreview(Graphics g);
        void draw(Graphics g);
        Image generateDrawingImageAndThumb(int examImageId, string path, int width, int height);
        IDrawing deepCopy();
    }
}
