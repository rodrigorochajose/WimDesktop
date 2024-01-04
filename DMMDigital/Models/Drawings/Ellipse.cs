using DMMDigital.Interface;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace DMMDigital.Models.Drawings
{
    public class Ellipse : IDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }

        public void drawPreview(Graphics g)
        {
            g.DrawEllipse(new Pen(drawingColor, drawingSize), initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
        }

        public void draw(Graphics g)
        {
            graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(new Rectangle(initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y));

            g.DrawEllipse(new Pen(drawingColor, drawingSize), initialPosition.X, initialPosition.Y, finalPosition.X - initialPosition.X, finalPosition.Y - initialPosition.Y);
        }

        public Image generateDrawingImageAndThumb(int frameId, string path, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            draw(graphics);
            bitmap.Save(Path.Combine(path, $"F{frameId}-D{id}.png"));

            Image thumb = bitmap.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
            return thumb;
        }
    }
}
