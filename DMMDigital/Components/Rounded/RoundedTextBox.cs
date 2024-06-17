using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DMMDigital.Components.Rounded
{
    public partial class RoundedTextBox : UserControl
    {
        private TextBox textBox;
        private string placeholderText;
        private Color borderColor = Color.FromArgb(223, 242, 246);

        public RoundedTextBox()
        {
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(5, 8),
                Width = Width - 10,
                Height = Height - 10,
                Size = new Size(200, 30),
                BackColor = Color.FromArgb(223, 242, 246),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = false
            };

            textBox.Enter += RemovePlaceholder;
            textBox.Leave += ShowPlaceholder;

            Controls.Add(textBox);
            Resize += new EventHandler(RoundedTextBox_Resize);

            ShowPlaceholder(null, null);
        }

        private void RoundedTextBox_Resize(object sender, EventArgs e)
        {
            textBox.Width = Width - 10;
            textBox.Height = Height - 10;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 10, 10, 180, 90);
                path.AddArc(Width - 11, 0, 10, 10, 270, 90);
                path.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
                path.AddArc(0, Height - 11, 10, 10, 90, 90);
                path.CloseAllFigures();

                using (SolidBrush brush = new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                using (Pen pen = new Pen(borderColor))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
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

        public TextBox innerTextBox
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
            set { textBox.BackColor = value; }
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

        public string PlaceholderText
        {
            get { return placeholderText; }
            set { placeholderText = value; ShowPlaceholder(null, null); }
        }
    }
}