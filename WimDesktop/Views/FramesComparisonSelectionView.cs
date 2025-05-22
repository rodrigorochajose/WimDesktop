using WimDesktop.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WimDesktop.Interface.IView;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class FramesComparisonSelectionView : Form, IFramesComparisonSelectionView
    {
        public List<Frame> frames { get; set; }
        public List<Frame> selectedFrames { get; set; }

        private int patientId = 0;

        public FramesComparisonSelectionView(List<Frame> frames, int patientId)
        {
            InitializeComponent();
            adjustComponent();
            associateEvents();

            selectedFrames = new List<Frame>();
            this.frames = frames;
            this.patientId = patientId;

            drawTemplate();
        }

        private void adjustComponent()
        {
            ActiveControl = labelTitle;
            pictureBoxIcon.Left = (panelHeader.Width - (pictureBoxIcon.Width + labelTitle.Width)) / 2;
            labelTitle.Left = pictureBoxIcon.Left + pictureBoxIcon.Width + 5;
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    buttonCompareClick(null, EventArgs.Empty);
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            buttonCancel.Click += delegate 
            { 
                Close(); 
            };
        }

        private void drawTemplate()
        {
            foreach (Frame frame in frames)
            {
                int width;
                int height;
                if (frame.orientation < 2)
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
                selectedImages.Add(frame.filteredImage ?? frame.originalImage);
            }

            if (selectedImages.Count < 2)
            {
                MessageBox.Show(Resources.messageComparisonSelection, Resources.titleComparison);
                return;
            }

            int formsQuantity = selectedImages.Count();

            if (formsQuantity == 2)
            {
                FramesComparisonView form = new FramesComparisonView(selectedImages, patientId);

                DialogResult result = form.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Close();
                }
                return;
            }

            Rectangle screenArea = Screen.PrimaryScreen.WorkingArea;

            int cols = (int)Math.Ceiling(Math.Sqrt(formsQuantity));
            int rows = (int)Math.Ceiling((double)formsQuantity / cols);

            int formWidth = screenArea.Width / cols;
            int formHeight = screenArea.Height / rows;

            int formIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                int actualCols = (row == rows - 1 && formsQuantity % cols != 0) ? formsQuantity % cols : cols;
                int adjustedFormWidth = screenArea.Width / actualCols;

                for (int col = 0; col < actualCols; col++)
                {
                    if (formIndex >= formsQuantity) break;

                    int x = col * adjustedFormWidth;
                    int y = row * formHeight;

                    MultiComparisonView form = new MultiComparisonView(selectedImages[formIndex], patientId)
                    {
                        StartPosition = FormStartPosition.Manual,
                        Size = new Size(adjustedFormWidth, formHeight),
                        Location = new Point(x, y),
                        Owner = null
                    };

                    form.Show();
                    formIndex++;
                }
            }
        }
    }
}
