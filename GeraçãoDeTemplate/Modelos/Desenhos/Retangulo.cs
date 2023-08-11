using GeraçãoDeTemplate.Interface;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeraçãoDeTemplate
{
    internal class Retangulo : iDesenho
    {
        public int id { get; set; }
        public Point posicaoInicial { get; set; }

        public Point posicaoFinal { get; set; }

        public GraphicsPath graphicsPath { get; set; }


        public void desenharPrevia(Graphics g, Pen p)
        {
            g.DrawRectangle(p, validarRetangulo(posicaoInicial, posicaoFinal));
        }

        public void desenhar(Graphics g, Pen p)
        {
            graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(validarRetangulo(posicaoInicial, posicaoFinal));
            g.DrawRectangle(p, validarRetangulo(posicaoInicial, posicaoFinal));
        }

        private Rectangle validarRetangulo(Point posicaoInicial, Point posicaoFinal)
        {
            int pontoX = posicaoInicial.X;
            int pontoY = posicaoInicial.Y;
            int largura = posicaoFinal.X - posicaoInicial.X;
            int altura = posicaoFinal.Y - posicaoInicial.Y;


            if (largura < 0)
            {
                pontoX = posicaoFinal.X;
                largura = posicaoInicial.X - posicaoFinal.X;
            }
            if (altura < 0)
            {
                pontoY = posicaoFinal.Y;
                altura = posicaoInicial.Y - posicaoFinal.Y;
            }

            return new Rectangle(pontoX, pontoY, largura, altura);
        }

        public Object Clone()
        {
            return new Retangulo
            {
                id = this.id,
                posicaoInicial = this.posicaoInicial,
                posicaoFinal = this.posicaoFinal,
                graphicsPath = this.graphicsPath
            };
        }
    }
}
