using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DMMDigital.Components.Rounded
{
    public partial class RoundedMaskedTextBox : UserControl
    {
        private readonly MaskedTextBox maskedTextBox;
        private Color borderColor = Color.Red; 
        private int borderSize = 2;
        private int borderRadius = 10;

        public RoundedMaskedTextBox()
        {
            InitializeComponent();

            maskedTextBox = new MaskedTextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(borderSize, borderSize),
                Width = Width - 2 * borderSize,
                Height = Height - 2 * borderSize,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                AutoSize = false
            };

            Controls.Add(maskedTextBox);
            Resize += new EventHandler(RoundedMaskedTextBox_Resize);
            Paint += new PaintEventHandler(RoundedMaskedTextBox_Paint);
        }

        private void RoundedMaskedTextBox_Resize(object sender, EventArgs e)
        {
            ResizeMaskedTextBox();
            Invalidate();
        }

        private void RoundedMaskedTextBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = GetRoundedRectanglePath(new Rectangle(0, 0, Width - 1, Height - 1), borderRadius))
            {
                using (Pen pen = new Pen(borderColor, borderSize))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        public MaskedTextBox InnerMaskedTextBox
        {
            get { return maskedTextBox; }
        }

        public new Color BackColor
        {
            get { return maskedTextBox.BackColor; }
            set
            {
                base.BackColor = value;
                maskedTextBox.BackColor = value;
                Invalidate();
            }
        }

        public new Color ForeColor
        {
            get { return maskedTextBox.ForeColor; }
            set
            {
                base.ForeColor = value;
                maskedTextBox.ForeColor = value;
            }
        }

        public new Font Font
        {
            get { return maskedTextBox.Font; }
            set
            {
                base.Font = value;
                maskedTextBox.Font = value;
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                ResizeMaskedTextBox();
                Invalidate();
            }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        private void ResizeMaskedTextBox()
        {
            maskedTextBox.Location = new Point(borderSize, borderSize);
            maskedTextBox.Width = Width - 2 * borderSize;
            maskedTextBox.Height = Height - 2 * borderSize;
        }
    }
}
