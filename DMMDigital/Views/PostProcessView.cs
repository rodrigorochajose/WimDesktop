using DMMDigital.Interface.IView;
using DMMDigital.Properties;
using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV.Util;

namespace DMMDigital.Views
{
    public partial class PostProcessView : Form, IPostProcessView
    {
        public float brightness 
        {
            get { return (float) numericUpDownBrightness.InnerNumericUpDown.Value; }
            set { numericUpDownBrightness.InnerNumericUpDown.Value = (decimal) value; }
        }

        public float contrast 
        {
            get { return (float)numericUpDownContrast.InnerNumericUpDown.Value; }
            set { numericUpDownContrast.InnerNumericUpDown.Value = (decimal)value; }
        }

        public float reveal 
        {
            get { return (float)numericUpDownReveal.InnerNumericUpDown.Value; }
            set { numericUpDownReveal.InnerNumericUpDown.Value = (decimal)value; }
        }

        public float smartSharpen
        {
            get { return (float)numericUpDownSmartSharpen.InnerNumericUpDown.Value; }
            set { numericUpDownSmartSharpen.InnerNumericUpDown.Value = (decimal)value; }
        }

        public PostProcessView(float brightness, float contrast, float reveal, float smartSharpen)
        {
            InitializeComponent();

            this.brightness = brightness;
            this.contrast = contrast;
            this.reveal = reveal;
            this.smartSharpen = smartSharpen;

            pictureBoxOriginalImage.Image = Resources.imageConfigFilter;
            pictureBoxFilteredImage.Image = Resources.imageConfigFilter;
        }

        private void buttonImportClick(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image selectedImage = Image.FromStream(openFileDialog1.OpenFile());

                pictureBoxOriginalImage.Image = selectedImage;
                pictureBoxFilteredImage.Image = selectedImage;
            }
        }

        private void buttonApplyClick(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBoxOriginalImage.Image); 

            image = Filters.applyBrightnessAndContrast(image, brightness / 4, contrast);
            image = Filters.applyReveal(image, reveal);
            image = Filters.applySmartSharpen(image, smartSharpen);

            pictureBoxFilteredImage.Image = image;
            Refresh();
        }

        private void buttonRestoreImageClick(object sender, EventArgs e)
        {
            pictureBoxFilteredImage.Image = new Bitmap(pictureBoxOriginalImage.Image);
        }

        private void buttonRestoreValuesClick(object sender, EventArgs e)
        {
            numericUpDownBrightness.InnerNumericUpDown.Value = 0;
            numericUpDownContrast.InnerNumericUpDown.Value = 0;
            numericUpDownReveal.InnerNumericUpDown.Value = 0;
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}