using DMMDigital.Interface.IView;
using DMMDigital.Presenters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class FramesComparisonView : Form
    {
        public List<Image> images { get; set; }

        private PictureBox selectedPictureBox;
        private PictureBox overlayPictureBox;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();

        private int patientId = 0;

        public FramesComparisonView(List<Image> images, int patientId)
        {
            InitializeComponent();
            this.images = images;
            this.patientId = patientId;

            associateEvents();
        }

        private void associateEvents()
        {
            buttonClose.Click += delegate { Close(); };

            buttonBack.Click += delegate
            {
                DialogResult = DialogResult.Ignore;
                Close();
            };

        }

        private void generatePanelOverlay()
        {
            Panel p = new Panel
            {
                BackColor = Color.LightGray,
                Dock = DockStyle.Fill,
                Name = "panelOverlay"
            };

            overlayPictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = selectedPictureBox.Image
            };

            p.Controls.Add(overlayPictureBox);
            Controls.Add(p);
            Refresh();
        }
        
        private void buttonOverlayClick(object sender, EventArgs e)
        {
            labelOpacity.Visible = !labelOpacity.Visible;
            trackBarOpacity.Visible = !trackBarOpacity.Visible;

            if (tableLayoutPanel.Visible)
            {
                tableLayoutPanel.Visible = !tableLayoutPanel.Visible;

                generatePanelOverlay();
            }
            else
            {
                Controls.Remove(Controls.OfType<Panel>().First(p => p.Name == "panelOverlay"));

                tableLayoutPanel.Visible = !tableLayoutPanel.Visible;
            }
        }

        private void trackBarOpacityScroll(object sender, EventArgs e)
        {
            float transparency = trackBarOpacity.Value / 100f;

            Image backgroundImage = new Bitmap(selectedPictureBox.Image);
            Image foregroundImage = new Bitmap(pictureBoxes.First(p => p != selectedPictureBox).Image);

            overlayPictureBox.Image = combineImages(backgroundImage, foregroundImage, transparency);
        }

        private void buttonChangeSidesClick(object sender, EventArgs e)
        {
            (pictureBoxes[0].Image, pictureBoxes[1].Image) = (pictureBoxes[1].Image, pictureBoxes[0].Image);
        }

        private void buttonRotateClick(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(selectedPictureBox.Image);
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            selectedPictureBox.Image = img;
        }

        private void buttonImportImageClick(object sender, EventArgs e)
        {
            DialogResult result = dialogFileImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image selectedImage = Image.FromStream(dialogFileImage.OpenFile());

                selectedPictureBox.Image = selectedImage;
            }
        }

        private void compareFramesLoad(object sender, EventArgs e)
        {
            tableLayoutPanel.SuspendLayout();

            tableLayoutPanel.ColumnStyles.Clear();
            tableLayoutPanel.RowStyles.Clear();

            normalComparison();

            tableLayoutPanel.ResumeLayout();

            selectedPictureBox = pictureBoxes[0];
            selectedPictureBox.BackColor = Color.LightGray;
        }

        private void selectFrame(PictureBox pb)
        {
            pictureBoxes.ForEach(p => p.BackColor = Color.WhiteSmoke);
            selectedPictureBox = pb;
            selectedPictureBox.BackColor = Color.LightGray;
        }

        private void normalComparison()
        {
            tableLayoutPanel.ColumnCount--;

            for (int counter = 0; counter < images.Count; counter++)
            {
                PictureBox pb = new PictureBox
                {
                    Image = images[counter],
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0)
                };

                pb.Click += delegate { selectFrame(pb); };
                pictureBoxes.Add(pb);

                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableLayoutPanel.Width / images.Count));
                tableLayoutPanel.ColumnCount++;
                tableLayoutPanel.Controls.Add(pb, counter, 0);
            }
        }

        private Image combineImages(Image background, Image foreground, float transparency)
        {
            Bitmap combinedBitmap = new Bitmap(background.Width, background.Height);

            using (Graphics g = Graphics.FromImage(combinedBitmap))
            {
                g.DrawImage(background, new Rectangle(0, 0, combinedBitmap.Width, combinedBitmap.Height));

                ColorMatrix colorMatrix = new ColorMatrix
                {
                    Matrix33 = transparency
                };

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(foreground, new Rectangle(0, 0, combinedBitmap.Width, combinedBitmap.Height), 0, 0, foreground.Width, foreground.Height, GraphicsUnit.Pixel, attributes);
            }

            return combinedBitmap;
        }

        private void buttonImportExamImageClick(object sender, EventArgs e)
        {
            IFramesComparisonImportView framesComparisonImportView = new FramesComparisonImportView("single");
            new ImportExamImagePresenter(framesComparisonImportView, patientId);

            selectedPictureBox.Image = framesComparisonImportView.getSelectedImages().First();
        }
    }
}

