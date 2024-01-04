using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using DMMDigital.Interface;

namespace DMMDigital.Models.Drawings
{
    public class ImageDrawed : IDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public Image img { get; set; }

        public void drawPreview(Graphics g)
        {
        }

        public void draw(Graphics g)
        {
            g.DrawImage(img, 0, 0);
        }

        public Image generateDrawingImageAndThumb(int frameId, string path, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            draw(graphics);

            Image thumb = bitmap.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
            return thumb;
        }
    }
}
