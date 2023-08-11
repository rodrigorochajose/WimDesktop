using GeraçãoDeTemplate.Interface;
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeraçãoDeTemplate
{
    internal class DesenhoLivre : iDesenho
    {
        public int id { get; set; }

        public Point posicaoInicial { get; set; }

        public Point posicaoFinal { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public List<Point> pontos { get; set; }

        public void desenharPrevia(Graphics g, Pen p)
        {
        }

        public void desenhar(Graphics g, Pen p)
        {
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(pontos.ToArray());

            g.DrawLines(p, pontos.ToArray());
        }

        public Object Clone()
        {
            DesenhoLivre desenho = new DesenhoLivre
            {
                id = this.id,
                posicaoInicial = this.posicaoInicial,
                posicaoFinal = this.posicaoFinal,
                graphicsPath = this.graphicsPath,
                pontos = new List<Point>()
            };
            this.pontos.ForEach(ponto => desenho.pontos.Add(ponto));
            return desenho;
        }
    }
}
