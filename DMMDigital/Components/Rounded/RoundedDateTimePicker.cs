using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using DMMDigital.Properties;

namespace DMMDigital.Components.Rounded
{
    public class RoundedDateTimePicker : DateTimePicker
    {
        private Color skinColor = Color.FromArgb(223, 242, 246);
        private Color textColor = Color.Gray;
        private Color borderColor = Color.White;
        private int borderSize = 0;
        private int borderRadius = 1;

        private bool droppedDown = false;
        private Image calendarIcon = Resources.darkCalendar;
        private RectangleF iconButtonArea;
        private const int calendarIconWidth = 34;
        private const int arrowIconWidth = 17;

        public Color SkinColor
        {
            get 
            { 
                return skinColor; 
            }
            set
            {
                skinColor = value;
                Invalidate();
            }
        }

        public Color TextColor
        {
            get 
            { 
                return textColor; 
            }
            set 
            { 
                textColor = value; 
                Invalidate(); 
            }
        }

        public Color BorderColor
        {
            get 
            { 
                return borderColor; 
            }
            set 
            { 
                borderColor = value; 
                Invalidate(); 
            }
        }

        public int BorderSize
        {
            get 
            { 
                return borderSize;
            }
            set 
            { 
                borderSize = value; 
                Invalidate(); 
            }
        }

        public int BorderRadius
        {
            get 
            { 
                return borderRadius; 
            }
            set 
            { 
                borderRadius = Math.Max(1, value); 
                Invalidate(); 
            }
        }

        public RoundedDateTimePicker()
        {
            SetStyle(ControlStyles.UserPaint, true);
            MinimumSize = new Size(0, 35);
            Font = new Font(Font.Name, 9.5F);
        }

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            droppedDown = true;
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            base.OnCloseUp(eventargs);
            droppedDown = false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            e.Handled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics graphics = e.Graphics)
            using (Pen penBorder = new Pen(borderColor, borderSize))
            using (SolidBrush skinBrush = new SolidBrush(skinColor))
            using (SolidBrush openIconBrush = new SolidBrush(Color.FromArgb(50, 64, 64, 64)))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat textFormat = new StringFormat())
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                RectangleF clientArea = new RectangleF(0, 0, Width - 0.5F, Height - 0.5F);
                RectangleF iconArea = new RectangleF(clientArea.Width - calendarIconWidth, 0, calendarIconWidth, clientArea.Height);
                penBorder.Alignment = PenAlignment.Inset;
                textFormat.LineAlignment = StringAlignment.Center;

                using (GraphicsPath path = GetRoundedRectanglePath(clientArea, borderRadius))
                {
                    Region = new Region(path);
                    graphics.FillPath(skinBrush, path);

                    if (borderSize > 0)
                        graphics.DrawPath(penBorder, path);
                }

                graphics.DrawString("   " + Text, Font, textBrush, clientArea, textFormat);

                if (droppedDown)
                    graphics.FillRectangle(openIconBrush, iconArea);

                graphics.DrawImage(calendarIcon, Width - calendarIcon.Width - 9, (Height - calendarIcon.Height) / 2);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            int iconWidth = GetIconButtonWidth();
            iconButtonArea = new RectangleF(Width - iconWidth, 0, iconWidth, Height);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = iconButtonArea.Contains(e.Location) ? Cursors.Hand : Cursors.Default;
        }

        private int GetIconButtonWidth()
        {
            int textWidth = TextRenderer.MeasureText(Text, Font).Width;
            return textWidth <= Width - (calendarIconWidth + 20) ? calendarIconWidth : arrowIconWidth;
        }

        private GraphicsPath GetRoundedRectanglePath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
