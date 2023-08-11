using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using GeraçãoDeTemplate.Interface;

namespace GeraçãoDeTemplate
{
    internal class Texto : iDesenho
    {
        public int id { get; set; }
        public Point posicaoInicial { get; set; }

        public Point posicaoFinal { get; set; }

        public GraphicsPath graphicsPath { get; set; }

        public string texto { get; set; }

        public Font fonte { get; set; }

        public SolidBrush pincel { get; set; }

        public void desenharPrevia(Graphics g, Pen p)
        {
            g.DrawString(texto, fonte, pincel, posicaoInicial);
        }

        public void desenhar(Graphics g, Pen p)
        {

            FontFamily family = new FontFamily("Arial");
            int fontStyle = (int)FontStyle.Italic;
            int emSize = 26;
            StringFormat format = StringFormat.GenericDefault;

            graphicsPath = new GraphicsPath();
            graphicsPath.AddString(texto, family, fontStyle, emSize, posicaoInicial, format);

            g.DrawString(texto, fonte, pincel, posicaoInicial);
        }

        public Object Clone()
        {
            return new Texto
            {
                id = this.id,
                posicaoInicial = this.posicaoInicial,
                posicaoFinal = this.posicaoFinal,
                graphicsPath = this.graphicsPath,
                texto = this.texto,
                fonte = this.fonte,
                pincel = this.pincel
            };
        }
    }
}
