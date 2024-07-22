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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Frame frame = this;

            if (originalImage == null)
            {
                int orderFontSize;
                int directionFontSize;
                string direction = "";
                PointF directionPoint;

                if (Width > 35)
                {
                    orderFontSize = 20;
                    directionFontSize = 12;
                    directionPoint = new Point(frame.Width - 20, frame.Height - 20);
                }
                else
                {
                    orderFontSize = 10;
                    directionFontSize = 6;
                    directionPoint = new Point(frame.Width - 17, frame.Height - 12);
                }


                switch (frame.orientation)
                {
                    case "Vertical Cima":
                        direction = "\u2191";
                        directionPoint.X += 7;
                        break;

                    case "Horizontal Esquerda":
                        direction = "\u2190";
                        break;

                    case "Vertical Baixo":
                        direction = "\u2193";
                        directionPoint.X += 7;
                        break;

                    case "Horizontal Direita":
                        direction = "\u2192";
                        break;
                }


                e.Graphics.DrawString(frame.order.ToString(), new Font("TimesNewRoman", orderFontSize, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, new Point(0, 0));
                e.Graphics.DrawString(direction, new Font("TimesNewRoman", directionFontSize, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, directionPoint);
            }
        }
    }
}
