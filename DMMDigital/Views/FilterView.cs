using DMMDigital.Interface.IView;
using Emgu.CV;
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

            bindControls();
            applyFilters();
        }

        private void applyFilters()
        {
            Bitmap image = new Bitmap(originalImage);
            Mat matImg = image.ToMat();

            if (trackBarBrightness.Value != 0)
                matImg = Filters.applyBrightnessAndContrast(matImg, trackBarBrightness.Value / 4, 0);

            if (trackBarContrast.Value != 0)
                matImg = Filters.applyBrightnessAndContrast(matImg, 0, trackBarContrast.Value);

            if (trackBarReveal.Value != 0)
                matImg = Filters.applyReveal(matImg, trackBarReveal.Value);

            if (trackBarSmartSharpen.Value != 0)
                matImg = Filters.applySmartSharpen(matImg, trackBarSmartSharpen.Value);

            if (trackBarGamma.Value != 0)
                matImg = Filters.applyGamma(matImg, trackBarGamma.Value);

            if (trackBarEdge.Value != 0)
                matImg = Filters.applyEdge(matImg, trackBarEdge.Value);

            if (trackBarNoise.Value != 0)
                matImg = Filters.applyNoise(matImg, trackBarNoise.Value);

            if (checkBoxColorImage.Checked)
                matImg = Filters.colorImage(matImg, 0, 62, 158);

            if (checkBoxPositiveNegative.Checked)
                matImg = Filters.invertColors(matImg);

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

            checkBoxColorImage.CheckedChanged += (s, e) => applyFilters();
            checkBoxPositiveNegative.CheckedChanged += (s, e) => applyFilters();

            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape)
                    Close();
            };
        }

        private void restoreImage()
        {
            pictureBoxEditedImage.Image = pictureBoxOriginalImage.Image;
            resetControls();
            editedImage = new Bitmap(originalImage);
        }

        private void resetControls()
        {
            foreach (var control in new[]
            {
                trackBarBrightness, trackBarContrast, trackBarReveal,
                trackBarSmartSharpen, trackBarGamma, trackBarEdge, trackBarNoise
            })
            control.Value = 0;

            foreach (var control in new[]
            {
                numericUpDownBrightness, numericUpDownContrast, numericUpDownReveal,
                numericUpDownSmartSharpen, numericUpDownGamma, numericUpDownEdge, numericUpDownNoise
            })
            control.InnerNumericUpDown.Value = 0;

            checkBoxColorImage.Checked = false;
            checkBoxPositiveNegative.Checked = false;
        }

        private void buttonRestoreImageClick(object sender, EventArgs e) => restoreImage();

        private void buttonApplyChangesClick(object sender, EventArgs e)
        {
            originalImage = new Bitmap(editedImage);
            Close();
        }

        private void buttonBackClick(object sender, EventArgs e) => Close();
    }
}
