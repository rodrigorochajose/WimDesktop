using DMMDigital.Interface.IView;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Emgu.CV.Util;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;

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
                image = adjustBrightnessAndContrast(image, trackBarBrightness.Value / 4, 0);
            }

            if (trackBarContrast.Value != 0)
            {
                image = adjustBrightnessAndContrast(image, 0, trackBarContrast.Value);
            }

            if (trackBarReveal.Value != 0)
            {
                image = adjustReveal(image);
            }

            if (trackBarSmartSharpen.Value != 0)
            {
                image = adjustSmartSharpen(image);
            }

            if (checkBoxColorImage.Checked)
            {
                image = colorImage(image, 0, 62, 158);
            }

            if (checkBoxPositiveNegative.Checked)
            {
                image = invertColors(new Bitmap(image));
            }

            //image = PostProcessFilter.applyFilters(image, new float[] { trackBarGamma.Value, trackBarEdge.Value, trackBarNoise.Value});

            editedImage = image;
            pictureBoxEditedImage.Image = editedImage;
        }

        private Bitmap adjustBrightnessAndContrast(Bitmap image, int brightnessParam, int contrastParam)
        {
            //float brightnessScale = 1 + (float)(trackBarBrightness.Value / 100.0);
            //float contrastScale = (float)Math.Pow((100.0 + trackBarContrast.Value) / 100.0, 2);

            //ImageAttributes attributes = new ImageAttributes();
            //ColorMatrix colorMatrix = new ColorMatrix(new float[][]
            //{
            //    new float[] {contrastScale, 0, 0, 0, 0},
            //    new float[] {0, contrastScale, 0, 0, 0},
            //    new float[] {0, 0, contrastScale, 0, 0},
            //    new float[] {0, 0, 0, 1, 0},
            //    new float[] {-0.5f * (contrastScale - 1), -0.5f * (contrastScale - 1), -0.5f * (contrastScale - 1), 0, 1}
            //});

            //colorMatrix.Matrix00 *= brightnessScale;
            //colorMatrix.Matrix11 *= brightnessScale;
            //colorMatrix.Matrix22 *= brightnessScale;

            //attributes.SetColorMatrix(colorMatrix);

            //using (Graphics g = Graphics.FromImage(image))
            //{
            //    g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            //}

            //return image;

            Mat editedImage = image.ToMat();

            if (brightnessParam == 0 && contrastParam == 0)
            {
                return (Bitmap)image.Clone();
            }

            double brightnessValue = brightnessParam / 10.0;
            double pow = (brightnessValue > 0) ? 1.0 / (brightnessValue + 1) : -brightnessValue + 1;
            double normalize = Math.Pow(255, pow - 1);

            double contrastValue = contrastParam * 2.55;
            double contrastFactor = (259.0 * (contrastValue + 255)) / (255.0 * (259 - contrastValue));

            byte[] lookup = new byte[256];
            for (int i = 0; i < lookup.Length; i++)
            {
                double lookupValue = i; 
                lookupValue = (contrastFactor * (Math.Pow(lookupValue, pow) / normalize - 128) + 128);
                lookup[i] = (byte)(lookupValue < 0 ? 0 : (lookupValue > 255 ? 255 : lookupValue));
            }

            Mat dest = new Mat();
            CvInvoke.CvtColor(editedImage, dest, ColorConversion.Bgr2Bgra);

            byte[] destData = new byte[dest.Rows * dest.Cols * dest.NumberOfChannels];
            Marshal.Copy(dest.DataPointer, destData, 0, destData.Length);

            for (int i = 0; i < destData.Length; i += dest.NumberOfChannels)
            {
                byte a = destData[i + 3];
                byte r = destData[i + 2];
                byte g = destData[i + 1];
                byte b = destData[i];

                if (a == 0)
                {
                    Array.Clear(destData, i, dest.NumberOfChannels);
                }
                else
                {
                    r = lookup[r];
                    g = lookup[g];
                    b = lookup[b];

                    destData[i] = b;
                    destData[i + 1] = g;
                    destData[i + 2] = r;
                }
            }

            dest = new Mat(dest.Rows, dest.Cols, dest.Depth, dest.NumberOfChannels);
            Marshal.Copy(destData, 0, dest.DataPointer, destData.Length);

            Bitmap destBitmap = dest.ToImage<Bgra, byte>().ToBitmap();

            return destBitmap;
        }

        private Bitmap adjustReveal(Bitmap image)
        {
            //Mat grayImage = new Mat();
            //CvInvoke.CvtColor(inputImage, grayImage, ColorConversion.Bgr2Gray);

            //Mat blurredImage = new Mat();
            //CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(0, 0), trackBarReveal.Value + 1);

            //Mat unsharpMask = new Mat();
            //CvInvoke.AddWeighted(grayImage, 2.0, blurredImage, -1.0, 0, unsharpMask);
            //CvInvoke.CvtColor(unsharpMask, resultImage, ColorConversion.Gray2Bgr);

            Mat editedImage = image.ToMat();
            CvInvoke.DetailEnhance(image.ToMat(), editedImage, trackBarReveal.Value);

            return editedImage.ToBitmap();
        }

        private Bitmap adjustSmartSharpen(Bitmap image)
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

            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image.ToMat(), grayImage, ColorConversion.Bgr2Gray);

            Mat blurredImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(0, 0), trackBarSmartSharpen.Value + 1);

            Mat unsharpMask = new Mat();
            CvInvoke.AddWeighted(grayImage, 2.0, blurredImage, -1.0, 0, unsharpMask);

            return unsharpMask.ToBitmap();
            
        }

        public Bitmap colorImage(Bitmap srcBitmap, float redThreshold, float greenThreshold, float blueThreshold)
        {
            Image<Bgr, byte> bgrImage = srcBitmap.ToImage<Bgr, byte>();

            VectorOfMat bgrChannels = new VectorOfMat();
            CvInvoke.Split(bgrImage, bgrChannels);

            Mat redLookup = createLookupTable(redThreshold);
            Mat greenLookup = createLookupTable(greenThreshold);
            Mat blueLookup = createLookupTable(blueThreshold);

            CvInvoke.LUT(bgrChannels[2], redLookup, bgrChannels[2]);
            CvInvoke.LUT(bgrChannels[1], greenLookup, bgrChannels[1]);
            CvInvoke.LUT(bgrChannels[0], blueLookup, bgrChannels[0]);

            Mat destImage = new Mat();
            CvInvoke.Merge(bgrChannels, destImage);

            return destImage.ToBitmap();
        }

        private Mat createLookupTable(float threshold)
        {
            Mat lookup = new Mat(1, 256, DepthType.Cv8U, 1);

            float m1 = 255.0f / threshold;
            float m2 = 255.0f / (255.0f - threshold);

            byte[] lookupData = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                float lookupValue = (i > threshold) ? 255 - m2 * (i - threshold) : 255 - m1 * (threshold - i);
                lookupData[i] = (byte)Math.Max(0, Math.Min(255, lookupValue));
            }

            lookup.SetTo(lookupData);

            return lookup;
        }

        private Bitmap invertColors(Bitmap image)
        {
            BitmapData originalData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb
            );

            int byteCount = Math.Abs(originalData.Stride) * image.Height;
            byte[] pixels = new byte[byteCount];
            Marshal.Copy(originalData.Scan0, pixels, 0, byteCount);

            for (int i = 0; i < byteCount; i += 4)
            {
                pixels[i] = (byte)(255 - pixels[i]);         
                pixels[i + 1] = (byte)(255 - pixels[i + 1]); 
                pixels[i + 2] = (byte)(255 - pixels[i + 2]); 
            }

            Bitmap invertedBitmap = new Bitmap(image.Width, image.Height);
            BitmapData invertedData = invertedBitmap.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb
            );

            Marshal.Copy(pixels, 0, invertedData.Scan0, byteCount);

            image.UnlockBits(originalData);
            invertedBitmap.UnlockBits(invertedData);

            return invertedBitmap;
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

        private void trackBarNoiseValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBarNoise_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void trackBarEdgeValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBarEdge_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void trackBarGammaValueChanged(object sender, EventArgs e)
        {

        }

        private void trackBarGamma_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
    }
}
