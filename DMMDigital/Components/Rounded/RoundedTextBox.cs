using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DMMDigital.Components.Rounded
{
    public partial class RoundedTextBox : UserControl
    {
        private TextBox textBox;
        private Color borderColor = Color.Black;
        private int borderRadius = 15;

        public RoundedTextBox()
        {
            InitializeComponent();

            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(10, 7),
                Width = Width - 20,
                Height = Height - 14,
                BackColor = this.BackColor,
                ForeColor = this.ForeColor,
                Font = this.Font,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            Controls.Add(textBox);
            Resize += RoundedTextBox_Resize;
        }

        private void RoundedTextBox_Resize(object sender, EventArgs e)
        {
            textBox.Width = Width - 20;
            textBox.Height = Height - 14;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(Width - borderRadius, Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                using (Pen pen = new Pen(borderColor, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox.BackColor = value;
                Invalidate();
            }
        }

        public new Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox.ForeColor = value;
            }
        }

        public new Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox.Font = value;
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

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        public override string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
        }

        public TextBox innerTextBox
        {
            get { return textBox; }
        }
    }
}
