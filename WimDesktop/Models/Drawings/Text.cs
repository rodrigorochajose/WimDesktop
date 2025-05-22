using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using WimDesktop.Interface;
using System.Linq;

namespace WimDesktop.Models.Drawings
{
    public class Text : IDrawing
    {
        public int id { get; set; }
        public int examImageId { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }
        public List<Point> points { get; set; }
        public string text { get; set; }
        public Font font { get; set; }
        public SolidBrush brush { get; set; }

        public void drawPreview(Graphics g)
        {
            g.DrawString(text, font, brush, points.First());
        }

        public void draw(Graphics g)
        {
            FontFamily family = new FontFamily("Arial");
            int fontStyle = (int)FontStyle.Italic;
            float emSize = font.Size;
            StringFormat format = StringFormat.GenericDefault;

            SizeF sizeToFitText = g.MeasureString(text, font);

            graphicsPath = new GraphicsPath();
            graphicsPath.AddString(text, family, fontStyle, emSize, new RectangleF(points.First().X, points.First().Y, sizeToFitText.Width, sizeToFitText.Height), format);

            g.DrawString(text, font, brush, points.First());
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
            Text textCopy = new Text
            {
                id = id,
                examImageId = examImageId,
                graphicsPath = graphicsPath,
                drawingColor = drawingColor,
                drawingSize = drawingSize,
                points = points.Select(p => new Point(p.X, p.Y)).ToList(),
                text = text,
                font = font,
                brush = brush
            };

            return textCopy;
        }
    }
}
