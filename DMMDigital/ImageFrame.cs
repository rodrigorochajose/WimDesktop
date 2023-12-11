using System.Drawing;

namespace DMMDigital
{
    public class ImageFrame
    {
        public ImageFrame(int frame, Image image)
        {
            this.frame = frame;
            this.image = image;
        }

        public int frame { get; set; }
        public Image image { get; set; }

    }
}
