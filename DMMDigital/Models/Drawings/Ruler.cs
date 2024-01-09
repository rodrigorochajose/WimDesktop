using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Reflection;

namespace DMMDigital.Models.Drawings
{
    public class Ruler : IDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }
        public List<float> lineLength { get; set; }
        public bool multiple { get; set; }

        public void drawTotalLength(Graphics g)
        {
            g.DrawString(
                    lineLength.Sum().ToString("0.00") + "mm",
                    new Font("Arial", 14, FontStyle.Bold),
                    new SolidBrush(Color.Blue),
                    new Point(finalPosition.X + 10, finalPosition.Y)
                );
        }

        public void drawPreview(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize)
            {
                LineJoin = LineJoin.Bevel
            };
            g.DrawLine(pen, initialPosition, finalPosition);

            g.DrawString(
                lineLength.Sum().ToString("0.0"),
                new Font("Arial", 13),
                new SolidBrush(Color.Yellow),
                initialPosition
            );
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

            if (multiple)
            {
                for (int counter = 0; counter < points.Count - 1; counter++)
                {
                    g.DrawLine(pen, points[counter], points[counter + 1]);

                    g.DrawString(
                        lineLength[counter].ToString("0.00"),
                        new Font("Arial", 13),
                        new SolidBrush(Color.White),
                        new Point(
                            ((points[counter + 1].X - points[counter].X) / 2) + points[counter].X,
                            ((points[counter + 1].Y - points[counter].Y) / 2) + points[counter].Y
                        )
                    );
                }
                drawTotalLength(g);
            }
            else
            {
                g.DrawLine(pen, initialPosition, finalPosition);
                g.DrawString(
                    lineLength.Sum().ToString("0.00"), 
                    new Font("Arial", 13), 
                    new SolidBrush(Color.Purple), 
                    new Point(
                        ((finalPosition.X - initialPosition.X) / 2) + initialPosition.X,
                        ((finalPosition.Y - initialPosition.Y) / 2) + initialPosition.Y
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
