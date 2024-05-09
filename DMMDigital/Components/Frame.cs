using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Components
{
    public class Frame : PictureBox
    {
        public int order { get ; set; }
        public string orientation { get; set; }
        public Image originalImage { get; set; }
        public Image filteredImage { get; set; }
        public Image editedImage { get; set; }
        public string datePhotoTook { get; set; }
        public string notes { get; set; }
        public bool resize { get; set; }
    }
}
