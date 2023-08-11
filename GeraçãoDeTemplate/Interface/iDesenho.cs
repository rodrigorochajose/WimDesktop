using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeraçãoDeTemplate.Interface
{
    internal interface iDesenho : ICloneable
    {
        int id { get; set; }

        Point posicaoInicial { get; set; }

        Point posicaoFinal { get; set; }

        GraphicsPath graphicsPath { get; set; }

        void desenharPrevia(Graphics g, Pen p);

        void desenhar(Graphics g, Pen p);

    }
}
