using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace DMMDigital.Models.Drawings
{
    public class RectangleDraw : IDrawing
    {
        public int id { get; set; }
        public int frameId { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }

        private Rectangle setRectangle()
        {
            int initialPointX = points.First().X;
            int initialPointY = points.First().Y;
            int finalPointX = points.Last().X;
            int finalPointY = points.Last().Y;

            int width = finalPointX - initialPointX;
            int height = finalPointY - initialPointY;

            if (width < 0)
            {
                initialPointX = points.Last().X;
                width = points.First().X - points.Last().X;
            }
            if (height < 0)
            {
                initialPointY = points.Last().Y;
                height = points.First().Y - points.Last().Y;
            }

            return new Rectangle(initialPointX, initialPointY, width, height);
        }

        public void drawPreview(Graphics g)
        {
            g.DrawRectangle(new Pen(drawingColor, drawingSize), setRectangle());
        }

        public void draw(Graphics g)
        {
            Rectangle rec = setRectangle();
            graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(rec);
            g.DrawRectangle(new Pen(drawingColor, drawingSize), rec);
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
            RectangleDraw rectangleDrawCopy = new RectangleDraw
            {
                id = id,
                frameId = frameId,
                graphicsPath = graphicsPath,
                drawingColor = drawingColor,
                drawingSize = drawingSize,
                points = points.Select(p => new Point(p.X, p.Y)).ToList()
            };

            return rectangleDrawCopy;
        }
    }
}
