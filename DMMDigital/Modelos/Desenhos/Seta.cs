using DMMDigital.Interface;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DMMDigital
{
    public class Seta : iDesenho
    {
        public int id { get; set; }
        public Point posicaoInicial { get; set; }

        public Point posicaoFinal { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public void desenharPrevia(Graphics g, Pen p)
        {
            p.CustomEndCap = new AdjustableArrowCap(5, 5);
            g.DrawLine(p, posicaoInicial, posicaoFinal);
        }

        public void desenhar(Graphics g, Pen p)
        {
            p.CustomEndCap = new AdjustableArrowCap(5, 5);

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(posicaoInicial, posicaoFinal);

            g.DrawLine(p, posicaoInicial, posicaoFinal);
        }

        public Object Clone()
        {
            return new Seta
            {
                id = this.id,
                posicaoInicial = this.posicaoInicial,
                posicaoFinal = this.posicaoFinal,
                graphicsPath = this.graphicsPath
            };
        }
    }
}
