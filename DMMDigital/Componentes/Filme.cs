using System.ComponentModel;
using System.Windows.Forms;

namespace DMMDigital
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
