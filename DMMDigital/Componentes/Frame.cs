using System.ComponentModel;
using System.Windows.Forms;

namespace DMMDigital
{
    public class Frame : PictureBox
    {
        public int order { get ; set; }

        public string orientation { get; set; }

        public bool photoTook { get; set; }

        public Frame()
        {
        }

        public Frame(IContainer container)
        {
            container.Add(this);
        }
    }
}
