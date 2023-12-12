using DMMDigital.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ChooseFramesToCompare : Form, IChooseFramesToCompare
    {
        public List<Frame> framesToSelect { get; set; }
        public List<Frame> selectedFrames { get; set; }

        public ChooseFramesToCompare()
        {
            InitializeComponent();
        }

        private void chooseFramesToCompareLoad(object sender, EventArgs e)
        {
            drawTemplate();
            selectedFrames = new List<Frame>();
            ActiveControl = label1;
            comboBox1.SelectedIndex = 0;

            buttonCancel.Click += delegate { Close(); };
        }

        private void drawTemplate()
        {
            int width, height;

            foreach (Frame frame in framesToSelect)
            {
                if (frame.orientation.Contains("Vertical"))
                {
                    height = 70;
                    width = 50;
                }
                else
                {
                    height = 50;
                    width = 70;
                }

                Frame newFrame = new Frame
                {
                    Width = width,
                    Height = height,
                    BackColor = Color.Black,
                    Tag = Color.Black,
                    order = frame.order
                };

                if (frame.originalImage != null)
                {
                    newFrame.originalImage = frame.originalImage;
                    Image cloneOriginalImage = frame.originalImage.Clone() as Image;
                    newFrame.Image = cloneOriginalImage.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
                }
                else
                {
                    Bitmap image = new Bitmap(newFrame.Width, newFrame.Height);
                    Graphics graphics = Graphics.FromImage(image);
                    graphics.DrawString(frame.order.ToString(), new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, new Point(1, 1));
                    newFrame.Image = image;
                }

                newFrame.Location = new Point(frame.Location.X * 2, frame.Location.Y * 2);

                newFrame.Click += selectFrame;
                newFrame.Paint += paintFrameBorder;

                panel2.Controls.Add(newFrame);
            }
        }

        private void selectFrame(object sender, EventArgs e)
        {
            if ((Color)(sender as Frame).Tag == Color.LimeGreen)
            {
                (sender as Frame).Tag = Color.Black;
                selectedFrames.Remove(sender as Frame);
            } 
            else
            {
                (sender as Frame).Tag = Color.LimeGreen;
                selectedFrames.Add(sender as Frame);
            }
            (sender as Frame).Refresh();
        }

        private void paintFrameBorder(object sender, PaintEventArgs e)
        {
            Frame frame = sender as Frame;
            
            if ((Color)frame.Tag == Color.Black)
            {
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, ButtonBorderStyle.None);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid);
            }
        }

        private void buttonCompareClick(object sender, EventArgs e)
        {
            List<Image> selectedImages = selectedFrames.Select(f => f.originalImage).ToList();

            CompareFrames form = new CompareFrames { 
                selectedImages = selectedImages,
                compareMode = comboBox1.SelectedItem.ToString()
            };

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                Close();
            }
        }
    }
}
