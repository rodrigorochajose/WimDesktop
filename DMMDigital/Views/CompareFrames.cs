using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace DMMDigital.Views
{
    public partial class CompareFrames : Form
    {
        public List<Image> images { get; set; }

        private PictureBox selectedPictureBox;
        private PictureBox overlayPictureBox;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private bool multi = false;

        public CompareFrames(List<Image> images)
        {
            InitializeComponent();

            this.images = images;

            if (images.Count == 2)
            {
                panelTools.Visible = true;
                return;
            }

            multi = true;
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

        private void buttonCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBackClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
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

            overlayPictureBox.Image = CombineImages(backgroundImage, foregroundImage, transparency);
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

            if (multi)
            {
                multiComparison();
            }
            else
            {
                normalComparison();
            }

            tableLayoutPanel.ResumeLayout();

            if (pictureBoxes.Count == 2)
            {
                selectedPictureBox = pictureBoxes[0];
                selectedPictureBox.BackColor = Color.LightGray;
            }
        }

        private void selectFrame(PictureBox pb)
        {
            pictureBoxes.ForEach(p => p.BackColor = Color.WhiteSmoke);
            selectedPictureBox = pb;
            selectedPictureBox.BackColor = Color.LightGray;
        }

        private void multiComparison()
        {
            List<Image> horizontalImages = new List<Image>();
            List<Image> verticalImages = new List<Image>();

            foreach (Image img in images)
            {
                if (img.Width > img.Height)
                {
                    horizontalImages.Add(img);
                }
                else
                {
                    verticalImages.Add(img);
                }
            }

            int horizontalColumns = (int)Math.Ceiling((float)horizontalImages.Count / 3);
            int verticalColumns = (int)Math.Ceiling((float)verticalImages.Count / 2);

            if (horizontalColumns > 0)
            {
                tableLayoutPanel.ColumnStyles.Clear();
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (100 / horizontalColumns + verticalColumns) * horizontalColumns));
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (100 / horizontalColumns + verticalColumns) * verticalColumns));
                tableLayoutPanel.ColumnCount = 2;

                TableLayoutPanel tableHorizontalFrames = new TableLayoutPanel
                {
                    ColumnCount = horizontalColumns,
                    Dock = DockStyle.Fill,
                    Name = "horizontalTableLayoutPanel1",
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                    Margin = new Padding(0)
                };

                tableLayoutPanel.Controls.Add(tableHorizontalFrames, 0, 0);

                for (int columnCounter = 0; columnCounter < horizontalColumns; columnCounter++)
                {
                    int pbInserted = 0;

                    tableHorizontalFrames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableHorizontalFrames.Width / horizontalColumns));

                    TableLayoutPanel tableColumn = new TableLayoutPanel
                    {
                        ColumnCount = 1,
                        Dock = DockStyle.Fill,
                        Name = "horizontalTableLayoutPanel1",
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                        Margin = new Padding(0)
                    };

                    tableHorizontalFrames.Controls.Add(tableColumn, columnCounter, 0);

                    for (int rowCounter = 0; rowCounter < horizontalImages.Count; rowCounter++)
                    {
                        if (pbInserted == 3)
                        {
                            horizontalImages.RemoveRange(0, 3);
                            break;
                        }
                        else
                        {
                            PictureBox pb = new PictureBox
                            {
                                Image = horizontalImages[rowCounter],
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Dock = DockStyle.Fill,
                                Margin = new Padding(0)
                            };
                            pictureBoxes.Add(pb);
                            pbInserted++;

                            tableColumn.RowStyles.Add(new RowStyle(SizeType.Percent));
                            tableColumn.RowCount++;
                            tableColumn.Controls.Add(pb, 0, rowCounter);
                        }
                    }

                    for (int counter = 0; counter < pbInserted; counter++)
                    {
                        tableColumn.RowStyles[counter] = new RowStyle(SizeType.Percent, tableColumn.Height / pbInserted);
                    }
                }
            }

            if (verticalColumns > 0)
            {
                TableLayoutPanel tableVerticalFrames = new TableLayoutPanel
                {
                    ColumnCount = verticalColumns,
                    Dock = DockStyle.Fill,
                    Name = "tableVerticalFramesLayoutPanel1",
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                    Margin = new Padding(0)
                };

                tableLayoutPanel.Controls.Add(tableVerticalFrames, 1, 0);


                for (int columnCounter = 0; columnCounter < verticalColumns; columnCounter++)
                {
                    int pbInserted = 0;
                    tableVerticalFrames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableVerticalFrames.Width / verticalColumns));

                    TableLayoutPanel tableColumn = new TableLayoutPanel
                    {
                        ColumnCount = 1,
                        Dock = DockStyle.Fill,
                        Name = "tableColumn" + columnCounter,
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                        Margin = new Padding(0)
                    };

                    tableVerticalFrames.Controls.Add(tableColumn, columnCounter, 0);

                    for (int rowCounter = 0; rowCounter < verticalImages.Count; rowCounter++)
                    {
                        if (pbInserted == 2)
                        {
                            verticalImages.RemoveRange(0, 2);
                            break;
                        }
                        else
                        {
                            PictureBox pb = new PictureBox
                            {
                                Image = verticalImages[rowCounter],
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Dock = DockStyle.Fill,
                            };
                            pbInserted++;

                            tableColumn.RowStyles.Add(new RowStyle(SizeType.Percent));
                            tableColumn.RowCount++;
                            tableColumn.Controls.Add(pb, 0, rowCounter);
                        }
                    }

                    for (int counter = 0; counter < pbInserted; counter++)
                    {
                        tableColumn.RowStyles[counter] = new RowStyle(SizeType.Percent, tableColumn.Height / pbInserted);
                    }
                }
            }
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

        private Image CombineImages(Image background, Image foreground, float transparency)
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

    }
}

