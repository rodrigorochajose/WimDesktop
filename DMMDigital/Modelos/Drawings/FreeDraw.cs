using DMMDigital.Interface;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class FreeDraw : iDrawing
    {
        public int id { get; set; }

        public Point initialPosition { get; set; }

        public Point finalPosition { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public List<Point> points { get; set; }

        public void drawPreview(Graphics g, Pen p) {}

        public void draw(Graphics g, Pen p)
        {
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Round;
            p.LineJoin = LineJoin.Round;

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(points.ToArray());

            g.DrawLines(p, points.ToArray());
        }
    }
}
