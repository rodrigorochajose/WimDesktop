using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class FreeDraw : IDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }

        public void drawPreview(Graphics g) {}

        public void draw(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(points.ToArray());

            g.DrawLines(pen, points.ToArray());
        }

        public Image generateDrawingImageAndThumb(int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            draw(graphics);

            Image thumb = bitmap.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
            return thumb;
        }
    }
}
