using DMMDigital.Interface;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using MoreLinq;

namespace DMMDigital.Models.Drawings
{
    public class Ruler : IDrawing
    {
        public int id { get; set; }
        public int frameId { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }
        public Point previewPoint { get; set; }
        public List<float> lineLength { get; set; }
        public bool multiple { get; set; }

        public void drawTotalLength(Graphics g)
        {
            g.DrawString(
                    lineLength.Sum().ToString("0.00") + "mm",
                    new Font("Arial", 14, FontStyle.Bold),
                    new SolidBrush(drawingColor),
                    new Point(points.Last().X + 10, points.Last().Y)
                );
        }

        public void drawPreview(Graphics g)
        {
            Pen pen = new Pen(drawingColor, drawingSize)
            {
                LineJoin = LineJoin.Bevel
            };

            g.DrawLine(pen, points.Last(), previewPoint);

            g.DrawString(
                lineLength.Last().ToString("0.0"),
                new Font("Arial", 13),
                new SolidBrush(drawingColor),
                new Point(points.Last().X, points.Last().Y - 20)
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

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(points.ToArray());

            if (multiple)
            {
                for (int counter = 0; counter < points.Count - 1; counter++)
                {
                    g.DrawLine(pen, points[counter], points[counter + 1]);

                    g.DrawString(
                        lineLength[counter].ToString("0.00"),
                        new Font("Arial", 13),
                        new SolidBrush(drawingColor),
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
                Point firstPoint = points.First();
                Point lastPoint = points.Last();

                g.DrawLine(pen, firstPoint, lastPoint);
                g.DrawString(
                    lineLength.Sum().ToString("0.00"), 
                    new Font("Arial", 13), 
                    new SolidBrush(drawingColor), 
                    new Point(
                        ((lastPoint.X - firstPoint.X) / 2) + firstPoint.X,
                        ((lastPoint.Y - firstPoint.Y) / 2) + firstPoint.Y
                    )
                );
            }
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
            Ruler rulerCopy = new Ruler
            {
                id = id,
                frameId = frameId,
                graphicsPath = graphicsPath,
                drawingColor = drawingColor,
                drawingSize = drawingSize,
                points = points.Select(p => new Point(p.X, p.Y)).ToList(),
                previewPoint = previewPoint,
                lineLength = lineLength,
                multiple = multiple
            };

            return rulerCopy;
        }
    }
}
