using System.Drawing;
using System.Drawing.Drawing2D;
using DMMDigital.Interface;

namespace DMMDigital
{
    public class Text : IDrawing
    {
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

            graphicsPath = new GraphicsPath();
            graphicsPath.AddString(text, family, fontStyle, emSize, initialPosition, format);

            g.DrawString(text, font, brush, initialPosition);
        }
    }
}
