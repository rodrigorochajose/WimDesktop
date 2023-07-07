using GeraçãoDeTemplate.Modelos;
using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GeraçãoDeTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            // Horizontal Direita
            //img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            // Vertical Baixo
            //img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            // Horizontal Esquerda
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);

            pictureBox1.Image = img;
        }
    }
}
