using DMMDigital.Interface.IView;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class FilterView : Form, IFilterView
    {
        public Bitmap originalImage { get; set; }
        public Bitmap editedImage { get; set; }

        public FilterView(Bitmap image)
        {
            InitializeComponent();
            MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;

            originalImage = image;
            editedImage = image;
            pictureBoxOriginalImage.Image = image;
            pictureBoxEditedImage.Image = image;

            bindControls();
            applyFilters();
        }

        private void applyFilters()
        {
            Mat matImg = originalImage.ToMat();

            List<Func<Mat, Mat>> filters = new List<Func<Mat, Mat>>();

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
                matImg = filter(matImg);
            }

            editedImage = matImg.ToBitmap();
            pictureBoxEditedImage.Image = editedImage;
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

                trackBar.ValueChanged += (s, e) =>
                {
                    numericUpDown.InnerNumericUpDown.Value = trackBar.Value;
                    applyFilters();
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
            editedImage = new Bitmap(originalImage);
        }

        private void buttonApplyChangesClick(object sender, EventArgs e)
        {
            originalImage = new Bitmap(editedImage);
            Close();
        }

        private void buttonBackClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
