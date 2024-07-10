using DMMDigital.Interface.IView;
using System;
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
        }

        private void applyFilters()
        {
            Bitmap image = new Bitmap(originalImage);

            if (trackBarBrightness.Value != 0)
            {
                image = Filters.applyBrightnessAndContrast(image, trackBarBrightness.Value / 4, 0);
            }

            if (trackBarContrast.Value != 0)
            {
                image = Filters.applyBrightnessAndContrast(image, 0, trackBarContrast.Value);
            }

            if (trackBarReveal.Value != 0)
            {
                image = Filters.applyReveal(image, trackBarReveal.Value);
            }

            if (trackBarSmartSharpen.Value != 0)
            {
                image = Filters.applySmartSharpen(image, trackBarSmartSharpen.Value);
            }

            if (trackBarGamma.Value != 0)
            {
                image = Filters.applyGamma(image, trackBarGamma.Value);
            }

            if (trackBarEdge.Value != 0)
            {
                image = Filters.applyEdge(image, trackBarEdge.Value);
            }

            if (trackBarNoise.Value != 0)
            {
                image = Filters.applyNoise(image, trackBarNoise.Value);
            }

            if (checkBoxColorImage.Checked)
            {
                image = Filters.colorImage(image, 0, 62, 158);
            }

            if (checkBoxPositiveNegative.Checked)
            {
                image = Filters.invertColors(new Bitmap(image));
            }

            editedImage = image;
            pictureBoxEditedImage.Image = editedImage;
        }


        private void trackBarBrightnessMouseCaptureChanged(object sender, EventArgs e)
        {
            applyFilters();
            numericUpDownBrightness.Value = trackBarBrightness.Value;
        }

        private void numericUpDownBrightnessValueChanged(object sender, EventArgs e)
        {
            trackBarBrightness.Value = (int)numericUpDownBrightness.Value;
            applyFilters();
        }

        private void trackBarContrastMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownContrast.Value = trackBarContrast.Value;
            applyFilters();
        }

        private void numericUpDownContrastValueChanged(object sender, EventArgs e)
        {
            trackBarContrast.Value = (int)numericUpDownContrast.Value;
            applyFilters();
        }

        private void trackBarRevealMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownReveal.Value = trackBarReveal.Value;
            applyFilters();
        }

        private void numericUpDownRevealValueChanged(object sender, EventArgs e)
        {
            trackBarReveal.Value = (int)numericUpDownReveal.Value;
            applyFilters();
        }

        private void trackBarSmartSharpenMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownSmartSharpen.Value = trackBarSmartSharpen.Value;
            applyFilters();
        }

        private void numericUpDownSmartSharpenValueChanged(object sender, EventArgs e)
        {
            trackBarSmartSharpen.Value = (int)numericUpDownSmartSharpen.Value;
            applyFilters();
        }

        private void trackBarGammaMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownGamma.Value = trackBarGamma.Value;
            applyFilters();
        }

        private void numericUpDownGammaValueChanged(object sender, EventArgs e)
        {
            trackBarGamma.Value = (int)numericUpDownGamma.Value;
            applyFilters();
        }

        private void trackBarEdgeMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownEdge.Value = trackBarEdge.Value;
            applyFilters();
        }

        private void numericUpDownEdgeValueChanged(object sender, EventArgs e)
        {
            trackBarEdge.Value = (int)numericUpDownEdge.Value;
            applyFilters();
        }

        private void trackBarNoiseMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownNoise.Value = trackBarNoise.Value;
            applyFilters();
        }

        private void numericUpDownNoiseValueChanged(object sender, EventArgs e)
        {
            trackBarNoise.Value = (int)numericUpDownNoise.Value;
            applyFilters();
        }

        private void checkBoxColorImageCheckedChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void checkBoxPositiveNegativeCheckedChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void buttonRestoreImageClick(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 0;
            numericUpDownBrightness.Value = 0;
            trackBarContrast.Value = 0;
            numericUpDownContrast.Value = 0;
            trackBarReveal.Value = 0;
            numericUpDownReveal.Value = 0;
            trackBarSmartSharpen.Value = 0;
            numericUpDownSmartSharpen.Value = 0;
            trackBarGamma.Value = 0;
            numericUpDownGamma.Value = 0;
            trackBarEdge.Value = 0;
            numericUpDownEdge.Value = 0;
            trackBarNoise.Value = 0;
            numericUpDownNoise.Value = 0;
            checkBoxColorImage.Checked = false;
            checkBoxPositiveNegative.Checked = false;
        }

        private void buttonApplyChangesClick(object sender, EventArgs e)
        {
            originalImage = editedImage;
            Close();
        }

        private void buttonBackClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
