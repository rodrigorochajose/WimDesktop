using Saraff.Twain;
using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class Form1 : Form
    {
        private Twain32 _twain = new Twain32();


        public Form1()
        {
            InitializeComponent();
            _twain.OpenDSM();
            _twain.AcquireCompleted += _twain_AcquireCompleted;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _twain.CloseDataSource();
            _twain.SelectSource();
        }

       private void button1_Click(object sender, EventArgs e)
       {
            _twain.Acquire();
       }

        private void _twain_AcquireCompleted(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            if (_twain.ImageCount > 0)
            {
                pictureBox1.Image = _twain.GetImage(0);
            }
        }

    }
}
