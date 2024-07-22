using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DMMDigital.Components.Rounded
{
    public partial class RoundedTextBox : UserControl
    {
        private readonly TextBox textBox;
        private string placeholderText;
        private Color borderColor = Color.Red;
        private int borderSize = 2;
        private int borderRadius = 10;

        public RoundedTextBox()
        {
            InitializeComponent();

            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(borderSize, borderSize),
                Width = Width - 2 * borderSize,
                Height = Height - 2 * borderSize,
                Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                AutoSize = false
            };

            textBox.Enter += RemovePlaceholder;
            textBox.Leave += ShowPlaceholder;

            Controls.Add(textBox);
            Resize += new EventHandler(RoundedTextBox_Resize);
            Paint += new PaintEventHandler(RoundedTextBox_Paint);

            ShowPlaceholder(null, null);
        }

        private void RoundedTextBox_Resize(object sender, EventArgs e)
        {
            ResizeTextBox();
            Invalidate();
        }

        private void RoundedTextBox_Paint(object sender, PaintEventArgs e)
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

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = ForeColor;
            }
        }

        private void ShowPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;
            }
        }

        public TextBox InnerTextBox
        {
            get { return textBox; }
        }

        public override string Text
        {
            get { return textBox.Text == placeholderText ? "" : textBox.Text; }
            set { textBox.Text = value; ShowPlaceholder(null, null); }
        }

        public new Color BackColor
        {
            get { return textBox.BackColor; }
            set
            {
                base.BackColor = value;
                textBox.BackColor = value;
                Invalidate();
            }
        }

        public new Color ForeColor
        {
            get { return textBox.ForeColor; }
            set { textBox.ForeColor = value; }
        }

        public new Font Font
        {
            get { return textBox.Font; }
            set { textBox.Font = value; }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; ResizeTextBox(); Invalidate(); }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; Invalidate(); }
        }

        public string PlaceholderText
        {
            get { return placeholderText; }
            set { placeholderText = value; ShowPlaceholder(null, null); }
        }

        private void ResizeTextBox()
        {
            textBox.Location = new Point(borderSize, borderSize);
            textBox.Width = Width - 2 * borderSize;
            textBox.Height = Height - 2 * borderSize;
        }
    }
}
