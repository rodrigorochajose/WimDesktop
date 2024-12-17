using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Drawing;

namespace DMMDigital
{
    public static class Filters
    {
        public static Mat applyFilters(Mat input, params Func<Mat, Mat>[] filters)
        {
            Mat result = input.Clone();

            foreach (var filter in filters)
            {
                using (Mat temp = filter(result))
                {
                    result.Dispose();
                    result = temp.Clone();
                }
            }

            return result;
        }

        public static Mat applyGamma(Mat img, float value)
        {
            Mat output = new Mat(img.Size, DepthType.Cv8U, img.NumberOfChannels);

            float gamma = 1.0f / (1.0f + value * 0.1f);

            byte[] gammaTable = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                gammaTable[i] = (byte)Math.Min(255, Math.Max(0, Math.Pow(i / 255.0, gamma) * 255));
            }

            Mat lookupTable = new Mat(1, 256, DepthType.Cv8U, 1);
            lookupTable.SetTo(gammaTable);

            CvInvoke.LUT(img, lookupTable, output);

            return output;
        }

        public static Mat applyNoise(Mat img, float value)
        {
            Mat noiseImage = new Mat();

            CvInvoke.GaussianBlur(img, noiseImage, new Size(5, 5), 0);
            CvInvoke.AddWeighted(noiseImage, 1, noiseImage, 0, value, noiseImage);

            return noiseImage;
        }

        public static Mat applyEdge(Mat img, float value)
        {
            Mat edgeImage = new Mat();
            CvInvoke.Sobel(img, edgeImage, DepthType.Cv8U, 1, 0, 3);
            CvInvoke.AddWeighted(edgeImage, 1.2, img, 0.8, value, edgeImage);

            return edgeImage;
        }

        public static Mat applyBrightnessAndContrast(Mat image, float brightness, float contrast)
        {
            if (brightness == 0 && contrast == 0)
                return image.Clone();

            double contrastFactor = (259.0 * (contrast * 2.55 + 255)) / (255.0 * (259 - contrast * 2.55));

            byte[] lookup = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                lookup[i] = (byte)Math.Min(255, Math.Max(0, contrastFactor * (i - 128) + 128 + brightness * 10));
            }

            Mat lookupTable = new Mat(1, 256, DepthType.Cv8U, 1);
            lookupTable.SetTo<byte>(lookup);

            Mat result = new Mat();
            CvInvoke.LUT(image, lookupTable, result);

            return result;
        }

        public static Mat applyReveal(Mat image, float value)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            Mat blurredImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(0, 0), value);

            Mat sharpenedImage = new Mat();
            CvInvoke.AddWeighted(grayImage, 1.5, blurredImage, -0.5, 0, sharpenedImage);

            Mat resultImage = new Mat();
            CvInvoke.CvtColor(sharpenedImage, resultImage, ColorConversion.Gray2Bgr);

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

        public static Mat invertColors(Mat image)
        {
            Mat invertedImage = image.Clone();
            CvInvoke.BitwiseNot(invertedImage, invertedImage);
            return invertedImage;
        }
    }
}