using Emgu.CV.CvEnum;
using Emgu.CV;
using System;
using System.Drawing;
using Emgu.CV.Util;

namespace WimDesktop
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
            if (value == 0)
                return img; 

            float gamma = 1.0f / (1.0f + value * 0.1f);

            byte[] gammaTable = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                gammaTable[i] = (byte)Math.Min(255, Math.Max(0, Math.Pow(i / 255.0, gamma) * 255));
            }

            using (Mat lookupTable = new Mat(1, 256, DepthType.Cv8U, 1)) 
            {
                lookupTable.SetTo(gammaTable);

                Mat output = new Mat();
                CvInvoke.LUT(img, lookupTable, output); 

                return output;
            }
        }

        public static Mat applyNoise(Mat img, float value)
        {
            Mat noiseImage = new Mat();
            Mat tempImage = new Mat();

            CvInvoke.GaussianBlur(img, tempImage, new Size(5, 5), 0);
            CvInvoke.AddWeighted(tempImage, 1, tempImage, 0, value, noiseImage);

            tempImage.Dispose();

            return noiseImage;
        }

        public static Mat applyEdge(Mat img, float value)
        {
            Mat edgeImage = new Mat();
            Mat tempImage = new Mat();

            CvInvoke.Sobel(img, tempImage, DepthType.Cv8U, 1, 0, 3);
            CvInvoke.AddWeighted(tempImage, 1.2, img, 0.8, value, edgeImage);

            tempImage.Dispose();

            return edgeImage;
        }

        public static Mat applyBrightnessAndContrast(Mat image, float brightness, float contrast)
        {
            if (brightness == 0 && contrast == 0)
                return image;

            double contrastFactor = (259.0 * (contrast * 2.55 + 255)) / (255.0 * (259 - contrast * 2.55));

            byte[] lookup = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                lookup[i] = (byte)Math.Min(255, Math.Max(0, contrastFactor * (i - 128) + 128 + brightness * 10));
            }

            using (Mat lookupTable = new Mat(1, 256, DepthType.Cv8U, 1))
            {
                lookupTable.SetTo<byte>(lookup);

                Mat result = new Mat();
                CvInvoke.LUT(image, lookupTable, result);

                return result;
            }
        }

        public static Mat applyReveal(Mat image, float value)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            Mat resultImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, resultImage, new Size(0, 0), value);

            Mat sharpenedImage = new Mat();
            CvInvoke.AddWeighted(grayImage, 1.5, resultImage, -0.5, 0, sharpenedImage);

            CvInvoke.CvtColor(sharpenedImage, resultImage, ColorConversion.Gray2Bgr);

            sharpenedImage.Dispose();

            return resultImage;
        }

        public static Mat applySmartSharpen(Mat image, float value)
        {
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            Mat resultImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, resultImage, new Size(0, 0), value + 1);

            CvInvoke.AddWeighted(grayImage, 2.0, resultImage, -1.0, 0, resultImage);

            return resultImage;
        }

        public static Mat invertColors(Mat image)
        {
            Mat invertedImage = image.Clone();

            if (invertedImage.NumberOfChannels == 4)
            {
                CvInvoke.CvtColor(invertedImage, invertedImage, ColorConversion.Bgra2Bgr);
            }
            else
            {
                invertedImage = invertedImage.Clone();
            }

            CvInvoke.BitwiseNot(invertedImage, invertedImage);

            return invertedImage;
        }

        public static Mat colorImage(Mat img)
        {
            if (img.NumberOfChannels == 1)
            {
                CvInvoke.CvtColor(img, img, ColorConversion.Gray2Bgr);
            }
            else if (img.NumberOfChannels == 4)
            {
                CvInvoke.CvtColor(img, img, ColorConversion.Bgra2Bgr);
            }

            VectorOfMat bgrChannels = new VectorOfMat();
            CvInvoke.Split(img, bgrChannels);

            if (bgrChannels.Size != 3)
            {
                throw new Exception("Erro ao dividir os canais da imagem.");
            }

            using (Mat channel0 = bgrChannels[0], channel1 = bgrChannels[1], channel2 = bgrChannels[2])
            {
                CvInvoke.LUT(channel2, createLookupTable(0), channel2);
                CvInvoke.LUT(channel1, createLookupTable(62), channel1);
                CvInvoke.LUT(channel0, createLookupTable(158), channel0);

                Mat destImage = new Mat();
                CvInvoke.Merge(bgrChannels, destImage);

                return destImage;
            }
        }

        private static Mat createLookupTable(float threshold)
        {
            Mat lookup = new Mat(1, 256, DepthType.Cv8U, 1);
            float m1 = 255.0f / threshold;
            float m2 = 255.0f / (255.0f - threshold);

            using (Mat lookupData = new Mat(1, 256, DepthType.Cv8U, 1))
            {
                byte[] data = new byte[256];

                for (int i = 0; i < 256; i++)
                {
                    float lookupValue = (i > threshold) ? 255 - m2 * (i - threshold) : 255 - m1 * (threshold - i);
                    data[i] = (byte)Math.Min(255, Math.Max(0, lookupValue));
                }

                lookupData.SetTo(data);
                lookup = lookupData.Clone();
            }

            return lookup;
        }
    }
}