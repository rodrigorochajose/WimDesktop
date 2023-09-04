using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital.Interface
{
    public interface iDrawing
    {
        int id { get; set; }

        Point initialPosition { get; set; }

        Point finalPosition { get; set; }

        GraphicsPath graphicsPath { get; set; }

        void drawPreview(Graphics g, Pen p);

        void draw(Graphics g, Pen p);

    }
}
