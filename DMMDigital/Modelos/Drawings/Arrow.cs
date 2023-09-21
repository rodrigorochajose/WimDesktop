using DMMDigital.Interface;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class Arrow : IDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }

        public void drawPreview(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize);
            pen.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawLine(pen, initialPosition, finalPosition);
        }

        public void draw(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize);
            pen.CustomEndCap = new AdjustableArrowCap(5, 5);

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(initialPosition, finalPosition);

            g.DrawLine(pen, initialPosition, finalPosition);
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
