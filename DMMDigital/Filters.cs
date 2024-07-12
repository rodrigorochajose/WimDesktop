using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV.Util;
using System.Drawing.Imaging;

namespace DMMDigital
{
    public static class Filters
    {
        public static Bitmap applyPostProcessFilters(Bitmap image, float[] values)
        {
            float brightness = values[0];
            float contrast = values[1];
            float reveal = values[2];
            float smartSharpen = values[3];

            if (brightness != 0)
                image = applyBrightnessAndContrast(image, brightness, 0);

            if (contrast != 0)
                image = applyBrightnessAndContrast(image, 0, contrast);

            if (reveal != 0)
                image = applyReveal(image, reveal);

            if (smartSharpen != 0)
                image = applySmartSharpen(image, smartSharpen);

            return image;
        }

        public static Bitmap applyGamma(Bitmap img, float value)
        {
            Image<Gray, Byte> image = img.ToImage<Gray, Byte>();
            Image<Gray, Byte> imagemGamma = new Image<Gray, Byte>(image.Size);

            value = 1.0f / (1.0f + value * 0.1f);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    byte valor = (byte)(Math.Pow((double)image.Data[y, x, 0] / 255, value) * 255);
                    imagemGamma.Data[y, x, 0] = valor;
                }
            }

            return imagemGamma.ToBitmap();
        }

        public static Bitmap applyEdge(Bitmap img, float value)
        {
            Image<Gray, Byte> image = img.ToImage<Gray, Byte>();
            Image<Gray, Byte> imagemEdge = new Image<Gray, Byte>(image.Size);
            CvInvoke.Sobel(image, imagemEdge, DepthType.Cv8U, 1, 0, 3);

            CvInvoke.AddWeighted(imagemEdge, 1.2, image, 0.8, value, imagemEdge);

            return imagemEdge.ToBitmap();
        }

        public static Bitmap applyNoise(Bitmap img, float value)
        {
            Image<Gray, Byte> image = img.ToImage<Gray, Byte>();

            CvInvoke.GaussianBlur(image, image, new Size(5, 5), 0);

            CvInvoke.AddWeighted(image, 1, image, 0, value, image);

            return image.ToBitmap();
        }

        public static Bitmap applyBrightnessAndContrast(Bitmap image, float brightnessParam, float contrastParam)
        {
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

        public static Bitmap applyReveal(Bitmap image, float value)
        {
            Mat editedImage = image.ToMat();
            CvInvoke.DetailEnhance(image.ToMat(), editedImage, value);

            return editedImage.ToBitmap();
        }

        public static Bitmap applySmartSharpen(Bitmap image, float value)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image.ToMat(), grayImage, ColorConversion.Bgr2Gray);

            Mat blurredImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(0, 0), value + 1);

            Mat unsharpMask = new Mat();
            CvInvoke.AddWeighted(grayImage, 2.0, blurredImage, -1.0, 0, unsharpMask);

            return unsharpMask.ToBitmap();
        }

        public static Bitmap colorImage(Bitmap srcBitmap, float redThreshold, float greenThreshold, float blueThreshold)
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

        public static Mat createLookupTable(float threshold)
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

        public static Bitmap invertColors(Bitmap image)
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
    }
}
