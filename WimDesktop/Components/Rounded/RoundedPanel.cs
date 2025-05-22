using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WimDesktop.Components.Rounded
{
    public partial class RoundedPanel : Panel
    {
        private int _cornerRadius = 20;
        private Color _borderColor = Color.Black;
        private float _borderWidth = 2f;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        public float BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            int d = _cornerRadius * 2;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(rect.X, rect.Y, d, d), 180, 90);
            path.AddArc(new Rectangle(rect.Right - d, rect.Y, d, d), 270, 90);
            path.AddArc(new Rectangle(rect.Right - d, rect.Bottom - d, d, d), 0, 90);
            path.AddArc(new Rectangle(rect.X, rect.Bottom - d, d, d), 90, 90);
            path.CloseFigure();

            Region = new Region(path);

            using (Pen pen = new Pen(_borderColor, _borderWidth))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }

}
