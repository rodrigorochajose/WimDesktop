using DMMDigital.Interface.IView;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace DMMDigital.Views
{
    public partial class FilterView : Form, IFilterView
    {
        public Mat originalImage { get; set; }
        public Mat editedImage { get; set; }

        private string imagePath = "";

        private List<Func<Mat, Mat>> filters = new List<Func<Mat, Mat>>();

        public FilterView(Bitmap image, string imagePath)
        {
            InitializeComponent();
            this.imagePath = imagePath; 

            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            originalImage = image.ToMat();
            editedImage = originalImage.Clone();

            pictureBoxOriginalImage.Image = originalImage.Clone();
            pictureBoxEditedImage.Image = originalImage.Clone();

            bindControls();
        }

        private void applyFilters()
        {
            editedImage?.Dispose();
            editedImage = originalImage.Clone();

            filters.Clear();

            if (trackBarBrightness.Value != 0)
                filters.Add(img => Filters.applyBrightnessAndContrast(img, trackBarBrightness.Value / 4, 0));

            if (trackBarContrast.Value != 0)
                filters.Add(img => Filters.applyBrightnessAndContrast(img, 0, trackBarContrast.Value));

            if (trackBarReveal.Value != 0)
                filters.Add(img => Filters.applyReveal(img, trackBarReveal.Value));

            if (trackBarSmartSharpen.Value != 0)
                filters.Add(img => Filters.applySmartSharpen(img, trackBarSmartSharpen.Value));

            if (trackBarGamma.Value != 0)
                filters.Add(img => Filters.applyGamma(img, trackBarGamma.Value));

            if (trackBarEdge.Value != 0)
                filters.Add(img => Filters.applyEdge(img, trackBarEdge.Value));

            if (trackBarNoise.Value != 0)
                filters.Add(img => Filters.applyNoise(img, trackBarNoise.Value));

            if (checkBoxPositiveNegative.Checked)
                filters.Add(img => Filters.invertColors(img));

            if (checkBoxColorImage.Checked)
                filters.Add(img => Filters.colorImage(img));

            foreach (var filter in filters)
            {
                editedImage = filter(editedImage);
            }

            pictureBoxEditedImage.Image.Dispose();
            pictureBoxEditedImage.Image = editedImage.Clone();
        }

        private void bindControls()
        {
            foreach (var control in new[]
            {
                (trackBarBrightness, numericUpDownBrightness),
                (trackBarContrast, numericUpDownContrast),
                (trackBarReveal, numericUpDownReveal),
                (trackBarSmartSharpen, numericUpDownSmartSharpen),
                (trackBarGamma, numericUpDownGamma),
                (trackBarEdge, numericUpDownEdge),
                (trackBarNoise, numericUpDownNoise)
            })
            {
                var trackBar = control.Item1;
                var numericUpDown = control.Item2;

                trackBar.MouseCaptureChanged += (s, e) =>
                {
                    numericUpDown.InnerNumericUpDown.Value = trackBar.Value;
                };

                numericUpDown.InnerNumericUpDown.ValueChanged += (s, e) =>
                {
                    trackBar.Value = (int)numericUpDown.InnerNumericUpDown.Value;
                    applyFilters();
                };
            }

            checkBoxPositiveNegative.CheckedChanged += delegate { applyFilters(); };
            checkBoxColorImage.CheckedChanged += delegate { applyFilters(); };

            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape)
                    Close();
            };
        }

        private void resetControls()
        {
            foreach (var control in new[] { trackBarBrightness, trackBarContrast, trackBarReveal, trackBarSmartSharpen, trackBarGamma, trackBarEdge, trackBarNoise })
                control.Value = 0;

            foreach (var control in new[] { numericUpDownBrightness, numericUpDownContrast, numericUpDownReveal, numericUpDownSmartSharpen, numericUpDownGamma, numericUpDownEdge, numericUpDownNoise })
                control.InnerNumericUpDown.Value = 0;

            checkBoxPositiveNegative.Checked = false;
        }

        private void buttonRestoreImageClick(object sender, EventArgs e)
        {
            pictureBoxEditedImage.Image = pictureBoxOriginalImage.Image;
            resetControls();
            editedImage = originalImage.Clone();
        }

        private void buttonApplyChangesClick(object sender, EventArgs e)
        {
            editedImage.Save(imagePath);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonBackClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void filterViewFormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBoxOriginalImage.Image?.Dispose();
            pictureBoxOriginalImage.Image = null;

            pictureBoxEditedImage.Image?.Dispose();
            pictureBoxEditedImage.Image = null;

            originalImage.Dispose();
            editedImage.Dispose();

            filters = null;
            Dispose();
        }
    }
}
