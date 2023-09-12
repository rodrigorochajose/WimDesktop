using DMMDigital.Interface;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class Ellipse : IDrawing
    {
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }

        public void drawPreview(Graphics g)
        {
            g.DrawEllipse(new Pen(drawingColor, drawingSize), initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
        }

        public void draw(Graphics g)
        {
            graphicsPath = new GraphicsPath();
            Rectangle retangulo = new Rectangle(initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
            graphicsPath.AddEllipse(retangulo);

            g.DrawEllipse(new Pen(drawingColor, drawingSize), initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
        }
    }
}
