using WimDesktop.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace WimDesktop.Models.Drawings
{
    public class FreeDraw : IDrawing
    {
        public int id { get; set; }
        public int examImageId { get; set; }
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
            FreeDraw freeDrawCopy = new FreeDraw
            {
                id = id,
                examImageId = examImageId,
                graphicsPath = graphicsPath,
                drawingColor = drawingColor,
                drawingSize = drawingSize,
                points = points.Select(p => new Point(p.X, p.Y)).ToList()
            };

            return freeDrawCopy;
        }
    }
}
