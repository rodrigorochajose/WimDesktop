using System;
using System.Windows.Forms;

namespace DMMDigital
{
    public class Frame : PictureBox
    {
        public int order { get ; set; }
        public string orientation { get; set; }
        public bool photoTook { get; set; }
        public string datePhotoTook { get; set; }
        public string notes { get; set; }
        

        public Frame()
        {
        }
    }
}
