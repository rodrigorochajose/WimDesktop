using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace DMMDigital.Models.Drawings
{
    public class Ellipse : IDrawing
    {
        public int id { get; set; }
        public int frameId { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }

        public void drawPreview(Graphics g)
        {
            g.DrawEllipse(new Pen(drawingColor, drawingSize), points.First().X, points.First().Y, points.Last().X - points.First().X, points.Last().Y - points.First().Y);
        }

        public void draw(Graphics g)
        {
            int initialPointX = points.First().X;
            int initialPointY = points.First().Y;
            int finalPointX = points.Last().X;
            int finalPointY = points.Last().Y;

            graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(new Rectangle(initialPointX, initialPointY, finalPointX - initialPointX, finalPointY - initialPointY));

            g.DrawEllipse(new Pen(drawingColor, drawingSize), initialPointX, initialPointY, finalPointX - initialPointX, finalPointY - initialPointY);
        }

        public Image generateDrawingImageAndThumb(int frameId, string path, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            draw(graphics);

            Image thumb = bitmap.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
            return thumb;
        }

        public IDrawing deepCopy()
        {
            Ellipse ellipseCopy = new Ellipse
            {
                id = id,
                frameId = frameId,
                graphicsPath = graphicsPath,
                drawingColor = drawingColor,
                drawingSize = drawingSize,
                points = points.Select(p => new Point(p.X, p.Y)).ToList()
            };

            return ellipseCopy;
        }
    }
}
