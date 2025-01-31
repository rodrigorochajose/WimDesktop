using DMMDigital.Interface.IView;
using DMMDigital.Presenters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class MultiComparisonView : Form
    {
        private float zoomFactor = 0.5f;
        private int patientId = 0;

        public MultiComparisonView(Image img, int patientId)
        {
            InitializeComponent();

            pictureBox.Image = img;

            this.patientId = patientId;

            associateEvents();
        }

        private void associateEvents()
        {
            toolStripButtonImportImage.Click += delegate { importImage(); };

            toolStripButtonImportExamImage.Click += delegate { importExamImage(); };

            toolStripButtonZoomIn.Click += delegate { zoomIn(); };

            toolStripButtonZoomOut.Click += delegate { zoomOut(); };

            toolStripButtonRotateLeft.Click += delegate { rotateImage("left"); };

            toolStripButtonRotateRight.Click += delegate { rotateImage("right"); };

            toolStripButtonCloseAll.Click += delegate { closeAll(); };
        }

        private void importImage()
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] selectedImages = openFileDialog.FileNames;

                foreach (string file in selectedImages)
                {
                    Image img = Image.FromFile(file);
                    MultiComparisonView form = new MultiComparisonView(img, patientId);
                    form.Show();
                }
            }
        }

        private void importExamImage()
        {
            IImportExamImageView importExamImageView = new ImportExamImageView("multi");

            new ImportExamImagePresenter(importExamImageView, patientId);

            List<Image> images = importExamImageView.getSelectedImages();

            getForms(images);
        }

        private void getForms(List<Image> images)
        {
            List<MultiComparisonView> forms = Application.OpenForms.OfType<MultiComparisonView>().ToList();

            forms.ForEach(f => f.Hide());

            foreach (Image img in images)
            {
                forms.Add(new MultiComparisonView(img, patientId));
            }

            showForms(forms);
        }

        private void showForms(List<MultiComparisonView> forms)
        {
            int formsQuantity = forms.Count;

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

                    forms[formIndex].StartPosition = FormStartPosition.Manual;
                    forms[formIndex].Size = new Size(adjustedFormWidth, formHeight);
                    forms[formIndex].Location = new Point(x, y);
                    forms[formIndex].Owner = null;

                    forms[formIndex].Show();
                    formIndex++;
                }
            }
        }

        private void rotateImage(string rotationDirection)
        {
            Bitmap currentImage = new Bitmap(pictureBox.Image);

            if (rotationDirection == "right")
            {
                currentImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
            {
                currentImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            pictureBox.Image = currentImage;
        }

        private void closeAll()
        {
            List<MultiComparisonView> openedForms = Application.OpenForms.OfType<MultiComparisonView>().ToList();

            foreach (MultiComparisonView form in openedForms)
            {
                form.Close();
            }
        }

        private void zoomIn()
        {
            zoomFactor += 0.1f;
            pictureBoxZoom();
        }

        private void zoomOut()
        {
            zoomFactor = Math.Max(0.1f, zoomFactor - 0.1f);
            pictureBoxZoom();
        }

        private void pictureBoxZoom()
        {
            int newWidth = (int)Math.Round(pictureBox.Image.Width * zoomFactor);
            int newHeight = (int)Math.Round(pictureBox.Image.Height * zoomFactor);

            if (newWidth < 50 || newHeight < 50 || newWidth > pictureBox.Image.Width * 10 || newHeight > pictureBox.Image.Height * 10)
            {
                return;
            }

            pictureBox.Size = new Size(newWidth, newHeight);

            panelContent.AutoScrollMinSize = new Size(newWidth, newHeight);

            pictureBox.Location = new Point((panelContent.Width - pictureBox.Width) / 2, (panelContent.Height - pictureBox.Height) / 2);
        }
    }
}
