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

            Mat matImage = image.ToMat();

            if (brightness != 0 || contrast != 0)
                matImage = applyBrightnessAndContrast(matImage, brightness, contrast);

            if (reveal != 0)
                matImage = applyReveal(matImage, reveal);

            if (smartSharpen != 0)
                matImage = applySmartSharpen(matImage, smartSharpen);

            return matImage.ToBitmap();
        }

        public static Mat applyGamma(Mat img, float value)
        {
            Mat gammaImage = new Mat();

            value = 1.0f / (1.0f + value * 0.1f);
            CvInvoke.Pow(img, value, gammaImage);

            return gammaImage;
        }

        public static Mat applyEdge(Mat img, float value)
        {
            Mat edgeImage = new Mat();
            CvInvoke.Sobel(img, edgeImage, DepthType.Cv8U, 1, 0, 3);
            CvInvoke.AddWeighted(edgeImage, 1.2, img, 0.8, value, edgeImage);

            return edgeImage;
        }

        public static Mat applyNoise(Mat img, float value)
        {
            Mat noiseImage = new Mat();

            CvInvoke.GaussianBlur(img, noiseImage, new Size(5, 5), 0);
            CvInvoke.AddWeighted(noiseImage, 1, noiseImage, 0, value, noiseImage);

            return noiseImage;
        }

        public static Mat applyBrightnessAndContrast(Mat image, float brightnessParam, float contrastParam)
        {
            if (brightnessParam == 0 && contrastParam == 0)
                return image.Clone();

            double brightnessValue = brightnessParam / 10.0;
            double pow = (brightnessValue > 0) ? 1.0 / (brightnessValue + 1) : -brightnessValue + 1;
            double normalize = Math.Pow(255, pow - 1);

            double contrastValue = contrastParam * 2.55;
            double contrastFactor = (259.0 * (contrastValue + 255)) / (255.0 * (259 - contrastValue));

            byte[] lookup = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                double lookupValue = i;
                lookupValue = (contrastFactor * (Math.Pow(lookupValue, pow) / normalize - 128) + 128);
                lookup[i] = (byte)(Math.Min(255, Math.Max(0, lookupValue)));
            }

            Mat lookupTable = new Mat(1, 256, DepthType.Cv8U, 1);
            lookupTable.SetTo<byte>(lookup);

            CvInvoke.LUT(image, lookupTable, image);

            return image;
        }

        public static Mat applyReveal(Mat image, float value)
        {
            Mat resultImage = new Mat();
            CvInvoke.DetailEnhance(image, resultImage, value);
            return resultImage;
        }

        public static Mat applySmartSharpen(Mat image, float value)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            Mat blurredImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(0, 0), value + 1);

            Mat unsharpMask = new Mat();
            CvInvoke.AddWeighted(grayImage, 2.0, blurredImage, -1.0, 0, unsharpMask);

            return unsharpMask;
        }

        public static Mat colorImage(Mat img, float redThreshold, float greenThreshold, float blueThreshold)
        {
            VectorOfMat bgrChannels = new VectorOfMat();
            CvInvoke.Split(img, bgrChannels);

            CvInvoke.LUT(bgrChannels[2], createLookupTable(redThreshold), bgrChannels[2]);
            CvInvoke.LUT(bgrChannels[1], createLookupTable(greenThreshold), bgrChannels[1]);
            CvInvoke.LUT(bgrChannels[0], createLookupTable(blueThreshold), bgrChannels[0]);

            Mat destImage = new Mat();
            CvInvoke.Merge(bgrChannels, destImage);

            return destImage;
        }

        private static Mat createLookupTable(float threshold)
        {
            Mat lookup = new Mat(1, 256, DepthType.Cv8U, 1);

            float m1 = 255.0f / threshold;
            float m2 = 255.0f / (255.0f - threshold);
            byte[] lookupData = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                float lookupValue = (i > threshold) ? 255 - m2 * (i - threshold) : 255 - m1 * (threshold - i);
                lookupData[i] = (byte)Math.Min(255, Math.Max(0, lookupValue));
            }

            lookup.SetTo(lookupData);
            return lookup;
        }

        public static Mat invertColors(Mat image)
        {
            Mat invertedImage = image.Clone();

            CvInvoke.BitwiseNot(invertedImage, invertedImage);

            return invertedImage;
        }

    }
}
