using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace DMMDigital.Models.Drawings
{
    public class Arrow : IDrawing
    {
        public int id { get; set; }
        public int examImageId { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }

        public void drawPreview(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize)
            {
                CustomStartCap = new AdjustableArrowCap(5, 5)
            };

            g.DrawLine(pen, points.First(), points.Last());
        }

        public void draw(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize)
            {
                CustomStartCap = new AdjustableArrowCap(5, 5)
            };

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(points.First(), points.Last());

            g.DrawLine(pen, points.First(), points.Last());
        }

        public Image generateDrawingImageAndThumb(int examImageId, string path, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            draw(graphics);

            Image thumb = bitmap.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
            return thumb;
        }

        public IDrawing deepCopy()
        {
            Arrow arrowCopy = new Arrow
            {
                id = id,
                examImageId = examImageId,
                graphicsPath = graphicsPath,
                drawingColor = drawingColor,
                drawingSize = drawingSize,
                points = points.Select(p => new Point(p.X, p.Y)).ToList()
            };

            return arrowCopy;
        }
    }
}
