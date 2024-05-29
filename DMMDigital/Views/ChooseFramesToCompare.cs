using DMMDigital.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Interface.IView;

namespace DMMDigital.Views
{
    public partial class ChooseFramesToCompare : Form, IChooseFramesToCompare
    {
        public List<Frame> frames { get; set; }
        public List<Frame> selectedFrames { get; set; }

        public ChooseFramesToCompare(List<Frame> frames)
        {
            InitializeComponent();
            ActiveControl = label1;

            selectedFrames = new List<Frame>();
            this.frames = frames;

            drawTemplate();

            buttonCancel.Click += delegate { Close(); };
        }

        private void drawTemplate()
        {
            foreach (Frame frame in frames)
            {
                int width;
                int height;
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
                    Tag = frame.Tag,
                    order = frame.order,
                    Location = new Point(frame.Location.X * 2, frame.Location.Y * 2)
                };

                if (frame.filteredImage != null)
                {
                    newFrame.originalImage = frame.originalImage;
                    newFrame.filteredImage = frame.filteredImage;
                    Image cloneOriginalImage = frame.filteredImage.Clone() as Image;
                    newFrame.Image = cloneOriginalImage.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
                }

                newFrame.Click += selectFrame;

                panelTemplate.Controls.Add(newFrame);
            }

            selectedFrames.Add(frames.First(p => (Color)p.Tag == Color.LimeGreen));
        }

        private void selectFrame(object sender, EventArgs e)
        {
            if ((sender as Frame).originalImage == null)
            {
                return;
            }

            Frame selectedFrame = (sender as Frame);

            if ((Color)selectedFrame.Tag == Color.LimeGreen)
            {
                selectedFrame.Tag = Color.Black;
                selectedFrames.Remove(selectedFrames.First(f => f.order == selectedFrame.order));
            } 
            else
            {
                selectedFrame.Tag = Color.LimeGreen;
                selectedFrames.Add(selectedFrame);
            }
            selectedFrame.Refresh();
        }

        private void buttonCompareClick(object sender, EventArgs e)
        {
            List<Image> selectedImages = new List<Image>();

            foreach (Frame frame in selectedFrames)
            {
                if (frame.filteredImage != null)
                {
                    selectedImages.Add(frame.filteredImage);
                }
                else
                {
                    selectedImages.Add(frame.originalImage);
                }
            }

            if (selectedImages.Count < 2)
            {
                MessageBox.Show("Selecione mais de uma imagem para comparação.", "Comparação de Imagens");
                return;
            }

            CompareFrames form = new CompareFrames(selectedImages);

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                Close();
            }
        }
    }
}
