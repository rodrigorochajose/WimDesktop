using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GeraçãoDeTemplate
{
    public class Filme : PictureBox
    {
        public int Ordem { get ; set; }

        public string Orientacao { get; set; }

        public bool ImagemCaptura { get; set; }

        public Filme()
        {
        }

        public Filme(IContainer container)
        {
            container.Add(this);
        }
    }
}
