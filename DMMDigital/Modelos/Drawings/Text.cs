using System.Drawing;
using System.Drawing.Drawing2D;
using DMMDigital.Interface;

namespace DMMDigital
{
    public class Text : iDrawing
    {
        public int id { get; set; }
        public Point initialPosition { get; set; }

        public Point finalPosition { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public string text { get; set; }

        public Font font { get; set; }

        public SolidBrush brush { get; set; }

        public void drawPreview(Graphics g, Pen p)
        {
            g.DrawString(text, font, brush, initialPosition);
        }

        public void draw(Graphics g, Pen p)
        {

            FontFamily family = new FontFamily("Arial");
            int fontStyle = (int)FontStyle.Italic;
            int emSize = 26;
            StringFormat format = StringFormat.GenericDefault;

            graphicsPath = new GraphicsPath();
            graphicsPath.AddString(text, family, fontStyle, emSize, initialPosition, format);

            g.DrawString(text, font, brush, initialPosition);
        }
    }
}
