using DMMDigital.Interface;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class Ellipse : iDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }

        public Point finalPosition { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public void drawPreview(Graphics g, Pen p)
        {
            g.DrawEllipse(p, initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
        }

        public void draw(Graphics g, Pen p)
        {
            graphicsPath = new GraphicsPath();
            Rectangle retangulo = new Rectangle(initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
            graphicsPath.AddEllipse(retangulo);

            g.DrawEllipse(p, initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
        }
    }
}
