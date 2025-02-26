using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DMMDigital.Components.Rounded
{
    public partial class RoundedComboBox : UserControl
    {
        private readonly ComboBox comboBox;
        private Color borderColor = Color.Red;
        private int borderSize = 2;
        private int borderRadius = 10;

        public RoundedComboBox()
        {
            InitializeComponent();

            comboBox = new ComboBox
            {
                FlatStyle = FlatStyle.Flat,
                Location = new Point(borderSize, borderSize),
                Width = Width - 2 * borderSize,
                Height = Height - 2 * borderSize
            };

            comboBox.TextChanged += (s, e) => OnTextChanged(e);

            Controls.Add(comboBox);
            Resize += new EventHandler(RoundedComboBox_Resize);
            Paint += new PaintEventHandler(RoundedComboBox_Paint);
        }

        private void RoundedComboBox_Resize(object sender, EventArgs e)
        {
            ResizeComboBox();
            Invalidate();
        }

        private void RoundedComboBox_Paint(object sender, PaintEventArgs e)
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

        public ComboBox InnerControl
        {
            get { return comboBox; }
        }

        public new Color BackColor
        {
            get { return comboBox.BackColor; }
            set
            {
                base.BackColor = value;
                comboBox.BackColor = value;
                Invalidate();
            }
        }

        public new Color ForeColor
        {
            get { return comboBox.ForeColor; }
            set 
            { 
                base.ForeColor = value;
                comboBox.ForeColor = value;
                Invalidate();
            }
        }

        public new Font Font
        {
            get { return comboBox.Font; }
            set 
            {
                base.Font = value;
                comboBox.Font = value;
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
            set { borderSize = value; ResizeComboBox(); Invalidate(); }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; Invalidate(); }
        }

        private void ResizeComboBox()
        {
            comboBox.Location = new Point(borderSize, borderSize);
            comboBox.Width = Width - 2 * borderSize;
            comboBox.Height = Height - 2 * borderSize;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }
    }
}
