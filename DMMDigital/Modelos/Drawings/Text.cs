using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using DMMDigital.Interface;

namespace DMMDigital
{
    public class Text : IDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public string text { get; set; }
        public Font font { get; set; }
        public SolidBrush brush { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }

        public void drawPreview(Graphics g)
        {
            g.DrawString(text, font, brush, initialPosition);
        }

        public void draw(Graphics g)
        {
            FontFamily family = new FontFamily("Arial");
            int fontStyle = (int)FontStyle.Italic;
            float emSize = font.Size;
            StringFormat format = StringFormat.GenericDefault;

            SizeF rectangleToDrawSize = g.MeasureString(text, font);
            graphicsPath.AddString(text, family, fontStyle, emSize, new RectangleF(initialPosition.X, initialPosition.Y, rectangleToDrawSize.Width, rectangleToDrawSize.Height), format);

            g.DrawString(text, font, brush, initialPosition);
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
