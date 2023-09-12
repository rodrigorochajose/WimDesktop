using DMMDigital.Interface;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class RectangleDraw : IDrawing
    {
        public Point initialPosition { get; set; }
        public Point finalPosition { get; set; }
        public GraphicsPath graphicsPath { get; set; }
        public Color drawingColor { get; set; }
        public float drawingSize { get; set; }

        private Rectangle setRectangle(Point initialPosition, Point finalPosition)
        {
            int pontoX = initialPosition.X;
            int pontoY = initialPosition.Y;
            int largura = finalPosition.X - initialPosition.X;
            int altura = finalPosition.Y - initialPosition.Y;


            if (largura < 0)
            {
                pontoX = finalPosition.X;
                largura = initialPosition.X - finalPosition.X;
            }
            if (altura < 0)
            {
                pontoY = finalPosition.Y;
                altura = initialPosition.Y - finalPosition.Y;
            }

            return new Rectangle(pontoX, pontoY, largura, altura);
        }

        public void drawPreview(Graphics g)
        {
            g.DrawRectangle(new Pen(drawingColor, drawingSize), setRectangle(initialPosition, finalPosition));
        }

        public void draw(Graphics g)
        {
            graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(setRectangle(initialPosition, finalPosition));
            g.DrawRectangle(new Pen(drawingColor, drawingSize), setRectangle(initialPosition, finalPosition));
        }

    }
}
