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

            associateEvents();
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

        private void associateEvents()
        {
            trackBarBrightness.MouseCaptureChanged += delegate
            {
                applyFilters();
                numericUpDownBrightness.InnerNumericUpDown.Value = trackBarBrightness.Value;
            };

            numericUpDownBrightness.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarBrightness.Value = (int)numericUpDownBrightness.InnerNumericUpDown.Value;
                applyFilters();
            };

            trackBarContrast.MouseCaptureChanged += delegate
            {
                numericUpDownContrast.InnerNumericUpDown.Value = trackBarContrast.Value;
                applyFilters();
            };

            numericUpDownContrast.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarContrast.Value = (int)numericUpDownContrast.InnerNumericUpDown.Value;
                applyFilters();
            };

            trackBarReveal.MouseCaptureChanged += delegate
            {
                numericUpDownReveal.InnerNumericUpDown.Value = trackBarReveal.Value;
                applyFilters();
            };

            numericUpDownReveal.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarReveal.Value = (int)numericUpDownReveal.InnerNumericUpDown.Value;
                applyFilters();
            };

            trackBarSmartSharpen.MouseCaptureChanged += delegate
            {
                numericUpDownSmartSharpen.InnerNumericUpDown.Value = trackBarSmartSharpen.Value;
                applyFilters();
            };

            numericUpDownSmartSharpen.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarSmartSharpen.Value = (int)numericUpDownSmartSharpen.InnerNumericUpDown.Value;
                applyFilters();
            };

            trackBarGamma.MouseCaptureChanged += delegate
            {
                numericUpDownGamma.InnerNumericUpDown.Value = trackBarGamma.Value;
                applyFilters();
            };

            numericUpDownGamma.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarGamma.Value = (int)numericUpDownGamma.InnerNumericUpDown.Value;
                applyFilters();
            };

            trackBarEdge.MouseCaptureChanged += delegate
            {
                numericUpDownEdge.InnerNumericUpDown.Value = trackBarEdge.Value;
                applyFilters();
            };

            numericUpDownEdge.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarEdge.Value = (int)numericUpDownEdge.InnerNumericUpDown.Value;
                applyFilters();
            };

            trackBarNoise.MouseCaptureChanged += delegate
            {
                numericUpDownNoise.InnerNumericUpDown.Value = trackBarNoise.Value;
                applyFilters();
            };

            numericUpDownNoise.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarNoise.Value = (int)numericUpDownNoise.InnerNumericUpDown.Value;
                applyFilters();
            };

            checkBoxColorImage.CheckedChanged += delegate
            {
                applyFilters();
            };

            checkBoxPositiveNegative.CheckedChanged += delegate
            {
                applyFilters();
            };
        }

        private void buttonRestoreImageClick(object sender, EventArgs e)
        {
            trackBarBrightness.Value = 0;
            numericUpDownBrightness.InnerNumericUpDown.Value = 0;
            trackBarContrast.Value = 0;
            numericUpDownContrast.InnerNumericUpDown.Value = 0;
            trackBarReveal.Value = 0;
            numericUpDownReveal.InnerNumericUpDown.Value = 0;
            trackBarSmartSharpen.Value = 0;
            numericUpDownSmartSharpen.InnerNumericUpDown.Value = 0;
            trackBarGamma.Value = 0;
            numericUpDownGamma.InnerNumericUpDown.Value = 0;
            trackBarEdge.Value = 0;
            numericUpDownEdge.InnerNumericUpDown.Value = 0;
            trackBarNoise.Value = 0;
            numericUpDownNoise.InnerNumericUpDown.Value = 0;
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
