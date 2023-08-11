using GeraçãoDeTemplate.Interface;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeraçãoDeTemplate
{
    internal class Circulo : iDesenho
    {
        public int id { get; set; }
        public Point posicaoInicial { get; set; }

        public Point posicaoFinal { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public void desenharPrevia(Graphics g, Pen p)
        {
            g.DrawEllipse(p, posicaoInicial.X, posicaoInicial.Y, posicaoFinal.X - posicaoInicial.X, posicaoFinal.Y - posicaoInicial.Y);
        }

        public void desenhar(Graphics g, Pen p)
        {
            graphicsPath = new GraphicsPath();
            Rectangle retangulo = new Rectangle(posicaoInicial.X, posicaoInicial.Y, posicaoFinal.X - posicaoInicial.X, posicaoFinal.Y - posicaoInicial.Y);
            graphicsPath.AddEllipse(retangulo);

            g.DrawEllipse(p, posicaoInicial.X, posicaoInicial.Y, posicaoFinal.X - posicaoInicial.X, posicaoFinal.Y - posicaoInicial.Y);
        }

        public Object Clone()
        {
            return new Circulo
            {
                id = this.id,
                posicaoInicial = this.posicaoInicial,
                posicaoFinal = this.posicaoFinal,
                graphicsPath = this.graphicsPath
            };
        }
    }
}
