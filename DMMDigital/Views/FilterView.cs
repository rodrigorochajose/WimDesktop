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

        private bool restore = false;

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
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            trackBarBrightness.MouseCaptureChanged += delegate
            {
                if (!restore)
                {
                    applyFilters();
                }

                numericUpDownBrightness.InnerNumericUpDown.Value = trackBarBrightness.Value;
            };

            numericUpDownBrightness.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarBrightness.Value = (int)numericUpDownBrightness.InnerNumericUpDown.Value;

                if (!restore)
                {
                    applyFilters();
                }
            };

            trackBarContrast.MouseCaptureChanged += delegate
            {
                numericUpDownContrast.InnerNumericUpDown.Value = trackBarContrast.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            numericUpDownContrast.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarContrast.Value = (int)numericUpDownContrast.InnerNumericUpDown.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            trackBarReveal.MouseCaptureChanged += delegate
            {
                numericUpDownReveal.InnerNumericUpDown.Value = trackBarReveal.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            numericUpDownReveal.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarReveal.Value = (int)numericUpDownReveal.InnerNumericUpDown.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            trackBarSmartSharpen.MouseCaptureChanged += delegate
            {
                numericUpDownSmartSharpen.InnerNumericUpDown.Value = trackBarSmartSharpen.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            numericUpDownSmartSharpen.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarSmartSharpen.Value = (int)numericUpDownSmartSharpen.InnerNumericUpDown.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            trackBarGamma.MouseCaptureChanged += delegate
            {
                numericUpDownGamma.InnerNumericUpDown.Value = trackBarGamma.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            numericUpDownGamma.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarGamma.Value = (int)numericUpDownGamma.InnerNumericUpDown.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            trackBarEdge.MouseCaptureChanged += delegate
            {
                numericUpDownEdge.InnerNumericUpDown.Value = trackBarEdge.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            numericUpDownEdge.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarEdge.Value = (int)numericUpDownEdge.InnerNumericUpDown.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            trackBarNoise.MouseCaptureChanged += delegate
            {
                numericUpDownNoise.InnerNumericUpDown.Value = trackBarNoise.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            numericUpDownNoise.InnerNumericUpDown.ValueChanged += delegate
            {
                trackBarNoise.Value = (int)numericUpDownNoise.InnerNumericUpDown.Value;
                
                if (!restore)
                {
                    applyFilters();
                }
            };

            checkBoxColorImage.CheckedChanged += delegate
            {
                if (!restore)
                {
                    applyFilters();
                }
            };

            checkBoxPositiveNegative.CheckedChanged += delegate
            {
                if (!restore)
                {
                    applyFilters();
                }
            };
        }

        private void buttonRestoreImageClick(object sender, EventArgs e)
        {
            restore = !restore;

            pictureBoxEditedImage.Image = pictureBoxOriginalImage.Image;

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

            restore = !restore;
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
