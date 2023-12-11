using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.Cuda;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;
using ImageProcessor.Processors;

namespace DMMDigital.Views
{
    public partial class FilterView : Form, IFilterView
    {
        public Bitmap originalImage { get; set; }
        public Bitmap editedImage { get; set; }

        public FilterView()
        {
            InitializeComponent();
        }

        private void FilterViewLoad(object sender, EventArgs e)
        {
            originalImage = new Bitmap(@"C:\Users\USER\.novowimdesktop\img\3-original.png");
            editedImage = originalImage;
            pictureBoxOriginalImage.Image = originalImage;
            pictureBoxNewImage.Image = editedImage;
        }

        private void applyFilters()
        {
            if (trackBarBrightness.Value != 0 || trackBarContrast.Value != 0)
            {
                adjustBrightnessAndContrast();
            }

            if (trackBarReveal.Value != 0)
            {
                adjustReveal();
            }

            if (trackBarSmartSharpen.Value != 0)
            {
                adjustSmartSharpen();
            }

            if (trackBarSmartRadius.Value != 0)
            {
                adjustSmartRadius();
            }

            if (checkBoxColorImage.Checked)
            {

            }

            if (checkBoxPositiveNegative.Checked)
            {
                invertColors();
            }

        }

        private void adjustBrightnessAndContrast()
        {
            float brightnessScale = 1 + (float)(trackBarBrightness.Value / 100.0);
            float contrastScale = (float)Math.Pow((100.0 + trackBarContrast.Value) / 100.0, 2);

            ImageAttributes attributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            {
                new float[] {contrastScale, 0, 0, 0, 0},
                new float[] {0, contrastScale, 0, 0, 0},
                new float[] {0, 0, contrastScale, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {-0.5f * (contrastScale - 1), -0.5f * (contrastScale - 1), -0.5f * (contrastScale - 1), 0, 1}
            });

            colorMatrix.Matrix00 *= brightnessScale;
            colorMatrix.Matrix11 *= brightnessScale;
            colorMatrix.Matrix22 *= brightnessScale;

            attributes.SetColorMatrix(colorMatrix);

            using (Graphics g = Graphics.FromImage(editedImage))
            {
                g.DrawImage(editedImage, new Rectangle(0, 0, editedImage.Width, editedImage.Height), 0, 0, editedImage.Width, editedImage.Height, GraphicsUnit.Pixel, attributes);
            }

            pictureBoxNewImage.Image = editedImage;
        }

        private void adjustReveal()
        {
            //Mat grayImage = new Mat();
            //CvInvoke.CvtColor(inputImage, grayImage, ColorConversion.Bgr2Gray);

            //Mat blurredImage = new Mat();
            //CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(0, 0), trackBarReveal.Value + 1);

            //Mat unsharpMask = new Mat();
            //CvInvoke.AddWeighted(grayImage, 2.0, blurredImage, -1.0, 0, unsharpMask);
            //CvInvoke.CvtColor(unsharpMask, resultImage, ColorConversion.Gray2Bgr);

            CvInvoke.DetailEnhance(editedImage.ToMat(), editedImage.ToMat(), trackBarReveal.Value);

            pictureBoxNewImage.Image = editedImage;
        }

        private void adjustSmartSharpen()
        {
            //Mat image = new Mat();
            //CvInvoke.CvtColor(originalImage.ToImage<Bgr, byte>(), image, ColorConversion.Bgr2Bgra);

            //int kernelSize = trackBarSmartSharpen.Value;

            //float[,] kernelArray = new float[kernelSize, kernelSize];
            //for (int i = 0; i < kernelSize; i++)
            //{
            //    for (int j = 0; j < kernelSize; j++)
            //    {
            //        kernelArray[i, j] = -1;
            //    }
            //}
            //kernelArray[kernelSize / 2, kernelSize / 2] = kernelSize * kernelSize;

            //Matrix<float> kernel = new Matrix<float>(kernelArray);

            //Mat sharpenedImage = new Mat();
            //CvInvoke.CvtColor(image, sharpenedImage, ColorConversion.Bgra2Bgr);

            //CvInvoke.Filter2D(sharpenedImage, sharpenedImage, kernel, new Point(-1, -1), 0, BorderType.Reflect101);

            //pictureBoxNewImage.Image = sharpenedImage.ToBitmap();

            Mat inputImage = editedImage.ToMat().Clone();

            Mat grayImage = new Mat();
            CvInvoke.CvtColor(inputImage, grayImage, ColorConversion.Bgr2Gray);

            Mat blurredImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(0, 0), trackBarSmartSharpen.Value + 1);

            Mat unsharpMask = new Mat();
            CvInvoke.AddWeighted(grayImage, 2.0, blurredImage, -1.0, 0, unsharpMask);

            editedImage = unsharpMask.ToBitmap();
            pictureBoxNewImage.Image = unsharpMask.ToBitmap();
            
        }

        private void adjustSmartRadius()
        {
            // Convert the original image to a Mat
            Mat image = new Mat();
            CvInvoke.CvtColor(originalImage.ToImage<Bgr, byte>(), image, ColorConversion.Bgr2Bgra);

            // Ensure the strength is within a reasonable range
            int strength = trackBarSmartRadius.Value;
            strength = Math.Max(1, strength); // Minimum kernel size is 1
            strength = (strength % 2 == 0) ? strength + 1 : strength; // Make it odd

            // Apply Gaussian blur to create a blurred version
            Mat blurredImage = new Mat();
            CvInvoke.GaussianBlur(image, blurredImage, new Size(strength, strength), 0);

            // Calculate the difference between the original and blurred images
            Mat sharpenedImage = new Mat();
            CvInvoke.AddWeighted(image, 1.5, blurredImage, -0.5, 0, sharpenedImage);

            // Display intermediate results (for debugging)
            pictureBoxOriginalImage.Image = image.ToBitmap();
            pictureBoxNewImage.Image = blurredImage.ToBitmap(); // Display blurred image
                                                                // pictureBoxNewImage.Image = sharpenedImage.ToBitmap(); // Display difference image

            // Display the result in the PictureBox
            pictureBoxNewImage.Image = sharpenedImage.ToBitmap();
        }

        private void invertColors()
        {
            Bitmap invertedBitmap = new Bitmap(editedImage.Width, editedImage.Height);

            BitmapData originalData = editedImage.LockBits(new Rectangle(0, 0, editedImage.Width, editedImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData invertedData = invertedBitmap.LockBits(new Rectangle(0, 0, invertedBitmap.Width, invertedBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* originalPtr = (byte*)originalData.Scan0;
                byte* invertedPtr = (byte*)invertedData.Scan0;

                int pixelCount = editedImage.Width * editedImage.Height;

                for (int i = 0; i < pixelCount; i++)
                {
                    // Invert each color channel
                    invertedPtr[0] = (byte)(255 - originalPtr[0]); // Blue
                    invertedPtr[1] = (byte)(255 - originalPtr[1]); // Green
                    invertedPtr[2] = (byte)(255 - originalPtr[2]); // Red
                    invertedPtr[3] = originalPtr[3]; // Alpha

                    originalPtr += 4;
                    invertedPtr += 4;
                }
            }

            editedImage.UnlockBits(originalData);
            invertedBitmap.UnlockBits(invertedData);

            pictureBoxNewImage.Image = invertedBitmap;
        }

        private void trackBarBrightnessMouseCaptureChanged(object sender, EventArgs e)
        {
            applyFilters();
            numericUpDownBrightness.Value = trackBarBrightness.Value;
        }

        private void numericUpDownBrightnessValueChanged(object sender, EventArgs e)
        {
            //trackBarBrightness.Value = (int)numericUpDownBrightness.Value;
        }

        private void trackBarContrastMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownContrast.Value = trackBarContrast.Value;
            applyFilters();
        }

        private void numericUpDownContrastValueChanged(object sender, EventArgs e)
        {
            //trackBarContrast.Value = (int)numericUpDownContrast.Value;
        }

        private void trackBarRevealMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownReveal.Value = trackBarReveal.Value;
            applyFilters();
        }

        private void numericUpDownRevealValueChanged(object sender, EventArgs e)
        {
            //trackBarReveal.Value = (int)numericUpDownReveal.Value;
        }

        private void trackBarSmartSharpenMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownSmartSharpen.Value = trackBarSmartSharpen.Value;
            applyFilters();
        }

        private void numericUpDownSmartSharpenValueChanged(object sender, EventArgs e)
        {
            //trackBarSmartSharpen.Value = (int)numericUpDownSmartSharpen.Value;
        }

        private void trackBarSmartRadiusMouseCaptureChanged(object sender, EventArgs e)
        {
            numericUpDownSmartRadius.Value = trackBarSmartRadius.Value;
            applyFilters();
        }

        private void numericUpDownSmartRadiusValueChanged(object sender, EventArgs e)
        {
            //trackBarSmartRadius.Value = (int)numericUpDownSmartRadius.Value;
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

        }

        private void buttonApplyChangesClick(object sender, EventArgs e)
        {

        }

        private void buttonBackClick(object sender, EventArgs e)
        {

        }
    }
}
