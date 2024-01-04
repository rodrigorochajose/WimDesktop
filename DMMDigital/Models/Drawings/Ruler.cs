using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.IO;

namespace DMMDigital.Models.Drawings
{
    internal class Ruler : IDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }

        public List<Point> points { get; set; }

        public List<float> lineLength { get; set; }

        public void drawPreview(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize)
            {
                LineJoin = LineJoin.Bevel
            };
            g.DrawLine(pen, initialPosition, finalPosition);


            if (lineLength.Last() > 0)
            {
                g.DrawString(
                    lineLength.Last().ToString("0.0"),
                    new Font("Arial", 13),
                    new SolidBrush(Color.White),
                    initialPosition
                );
            }
        }

        public void draw(Graphics g)
        {
            if (points.Count < 2)
                return;

            Pen pen = new Pen(drawingColor, drawingSize)
            {
                LineJoin = LineJoin.Bevel
            };

            graphicsPath.AddLines(points.ToArray());

            for (int counter = 0; counter < points.Count - 1; counter++)
            {
                g.DrawLine(pen, points[counter], points[counter + 1]);

                g.DrawString(
                    lineLength[counter].ToString("0.0"),
                    new Font("Arial", 13),
                    new SolidBrush(Color.White),
                    new Point(
                        ((points[counter + 1].X - points[counter].X) / 2) + points[counter].X,
                        ((points[counter + 1].Y - points[counter].Y) / 2) + points[counter].Y
                    )
                );
            }
            
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
