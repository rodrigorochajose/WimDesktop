using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DMMDigital.Components.Rounded
{
    public partial class RoundedNumericUpDown : UserControl
    {
        private readonly NumericUpDown numericUpDown;
        private Color borderColor = Color.Red;
        private int borderSize = 2;
        private int borderRadius = 10;

        public RoundedNumericUpDown()
        {
            InitializeComponent();

            numericUpDown = new NumericUpDown
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(borderSize, borderSize),
                Width = Width - 2 * borderSize,
                Height = Height - 2 * borderSize,
                AutoSize = false
            };

            numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            numericUpDown.KeyPress += NumericUpDown_KeyPress;

            Controls.Add(numericUpDown);
            Resize += new EventHandler(RoundedNumericUpDown_Resize);
            Paint += new PaintEventHandler(RoundedNumericUpDown_Paint);
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown.Value < numericUpDown.Minimum)
            {
                numericUpDown.Value = numericUpDown.Minimum;
            }
            else if (numericUpDown.Value > numericUpDown.Maximum)
            {
                numericUpDown.Value = numericUpDown.Maximum;
            }
        }

        private void NumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (numericUpDown.Value < numericUpDown.Minimum)
                {
                    numericUpDown.Value = numericUpDown.Minimum;
                }
                else if (numericUpDown.Value > numericUpDown.Maximum)
                {
                    numericUpDown.Value = numericUpDown.Maximum;
                }
            }
        }

        private void RoundedNumericUpDown_Resize(object sender, EventArgs e)
        {
            ResizeNumericUpDown();
            Invalidate();
        }

        private void RoundedNumericUpDown_Paint(object sender, PaintEventArgs e)
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

        public NumericUpDown InnerNumericUpDown
        {
            get { return numericUpDown; }
        }

        public new Color BackColor
        {
            get { return numericUpDown.BackColor; }
            set
            {
                base.BackColor = value;
                numericUpDown.BackColor = value;
                Invalidate();
            }
        }

        public new Color ForeColor
        {
            get { return numericUpDown.ForeColor; }
            set
            {
                base.ForeColor = value;
                numericUpDown.ForeColor = value;
                Invalidate();
            }
        }

        public new Font Font
        {
            get { return numericUpDown.Font; }
            set
            {
                base.Font = value;
                numericUpDown.Font = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; ResizeNumericUpDown(); Invalidate(); }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; Invalidate(); }
        }

        public decimal Minimum
        {
            get { return numericUpDown.Minimum; }
            set { numericUpDown.Minimum = value; }
        }

        public decimal Maximum
        {
            get { return numericUpDown.Maximum; }
            set { numericUpDown.Maximum = value; }
        }

        private void ResizeNumericUpDown()
        {
            numericUpDown.Location = new Point(borderSize, borderSize);
            numericUpDown.Width = Width - 2 * borderSize;
            numericUpDown.Height = Height - 2 * borderSize;
        }
    }
}
