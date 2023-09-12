using DMMDigital.Interface;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class FreeDraw : IDrawing
    {
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }

        public void drawPreview(Graphics g) {}

        public void draw(Graphics g)
        {
            Pen pen = new Pen (drawingColor, drawingSize);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(points.ToArray());

            g.DrawLines(pen, points.ToArray());
        }
    }
}
