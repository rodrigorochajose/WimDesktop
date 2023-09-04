using DMMDigital.Interface;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class Arrow : iDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }

        public Point finalPosition { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public void drawPreview(Graphics g, Pen p)
        {
            p.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawLine(p, initialPosition, finalPosition);
        }

        public void draw(Graphics g, Pen p)
        {
            p.CustomEndCap = new AdjustableArrowCap(5, 5);

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(initialPosition, finalPosition);

            g.DrawLine(p, initialPosition, finalPosition);
        }
    }
}
