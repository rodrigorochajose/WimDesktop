using FellowOakDicom;
using FellowOakDicom.Imaging;
using FellowOakDicom.Imaging.LUT;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WimDesktop.Components;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class ExportExamView : Form, IExportExamView
    {
        public string patientName { get; set; }
        public string pathImages { get; set; }
        public string pathToExport { get; set; }
        public bool waterMark { get; set; }
        public List<Frame> framesToExport { get; set; }

        private List<CheckBox> checkBoxFrames = new List<CheckBox>();

        public event EventHandler eventSaveExportPath;
        public event EventHandler eventGetExportPath;

        public ExportExamView()
        {
            InitializeComponent();
            adjustComponent();
            associateEvents();

            comboBoxFormat.InnerControl.DataSource = new List<string> { "JPG", "JPEG", "PNG", "TIFF", "DICOM", "RAW" };
            comboBoxFormat.InnerControl.SelectedIndex = 0;
        }

        private void adjustComponent()
        {
            pictureBoxIcon.Left = (panelHeader.Width - (pictureBoxIcon.Width + labelTitle.Width)) / 2;
            labelTitle.Left = pictureBoxIcon.Left + pictureBoxIcon.Width + 5;
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    DialogResult res = MessageBox.Show(Resources.messageExportExam, Text, MessageBoxButtons.YesNo);

                    if (res.Equals(DialogResult.Yes))
                    {
                        buttonExportExamClick(null, EventArgs.Empty);
                    }
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                }
            };

            buttonCancel.Click += delegate 
            { 
                Close(); 
            };
        }

        private void exportExamViewLoad(object sender, EventArgs e)
        {
            loadExamFrames();
            eventGetExportPath?.Invoke(this, EventArgs.Empty);

            roundedTextBoxSelectPath.Texts = pathToExport;

            roundedTextBoxSelectPath.Click += selectPath;
            buttonSelectPath.Click += selectPath;
        }

        public void loadExamFrames()
        {
            foreach (Frame frame in framesToExport)
            {
                Panel panel = new Panel {
                    Name = $"panelFrame{frame.order}",
                    Location = new Point(3, 3),
                    Size = new Size(450, 94)
                };

                if (frame.orientation > 1)
                {
                    frame.Location = new Point(17, 10);
                    frame.Size = new Size(85, 70);
                }
                else
                {
                    frame.Location = new Point(20, 5);
                    frame.Size = new Size(70, 85);
                }

                frame.Name = $"frame{frame.order}";
                frame.Image = frame.Image.GetThumbnailImage(frame.Width, frame.Height, () => false, IntPtr.Zero);

                Label label = new Label { 
                    Name = $"labelFrame{frame.order}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Location = new Point(120, 33),
                    Size = new Size(120, 17),
                    Text = $"Template - Frame {frame.order}"
                };

                CheckBox checkBox = new CheckBox { 
                    Name = $"checkBoxFrame{frame.order}",
                    AutoSize = true,
                    Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Location = new Point(410, 35),
                    Size = new Size(15, 14),
                    UseVisualStyleBackColor = true,
                    Checked = true,
                    Tag = frame.order
                };

                checkBoxFrames.Add(checkBox);

                panel.Controls.Add(checkBox);
                panel.Controls.Add(label);
                panel.Controls.Add(frame);

                flowLayoutPanel.Controls.Add(panel);
            }
        }

        public void selectPath(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();         
            pathToExport = folderBrowserDialog1.SelectedPath;
            roundedTextBoxSelectPath.Texts = folderBrowserDialog1.SelectedPath;
        }

        private void checkBoxSelectAllMouseCaptureChanged(object sender, EventArgs e)
        {
            if (checkBoxClearSelection.Checked)
            {
                checkBoxClearSelection.Checked = false;
            }

            foreach (CheckBox cb in checkBoxFrames)
            {
                cb.Checked = true;
            }
        }

        private void checkBoxClearSelectionMouseCaptureChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.Checked)
            {
                checkBoxSelectAll.Checked = false;
            }

            foreach (CheckBox cb in checkBoxFrames)
            {
                cb.Checked = false;
            }

            checkBoxClearSelection.Checked = true;
        }

        private List<ImageInfoExport> getImagesInfoToExport()
        {
            List<Frame> selectedFrames = flowLayoutPanel.Controls.OfType<Panel>()
                    .Where(panel => panel.Controls.OfType<CheckBox>().Any(c => c.Checked))
                    .Select(panel => panel.Controls.OfType<Frame>().FirstOrDefault())
                    .Where(frame => frame != null)
                    .ToList();

            List<ImageInfoExport> imagesInfo = new List<ImageInfoExport>();

            if (checkBoxExportOriginalImage.Checked)
            {
                string originalImagePath = "";

                foreach (Frame frame in selectedFrames)
                {
                    originalImagePath = Path.Combine(pathImages, $"{frame.order}_original.png");

                    using (Bitmap img = new Bitmap(originalImagePath))
                    {
                        imagesInfo.Add(new ImageInfoExport(frame.orientation, originalImagePath, (Bitmap) img.Clone()));
                    }

                }
            }

            if (checkBoxExportEditedImage.Checked)
            {
                foreach (Frame frame in selectedFrames)
                {
                    string editedImagePath = Path.Combine(pathImages, $"{frame.order}_edited.png");
                    string filteredImagePath = Path.Combine(pathImages, $"{frame.order}_filtered.png");

                    string imagePathToUse = File.Exists(editedImagePath) ? editedImagePath : File.Exists(filteredImagePath) ? filteredImagePath : null;

                    if (imagePathToUse != null)
                    {
                        using (Bitmap img = new Bitmap(imagePathToUse))
                        {
                            imagesInfo.Add(new ImageInfoExport(frame.orientation, imagePathToUse, (Bitmap)img.Clone()));
                        }
                    }
                }
            }

            return imagesInfo;
        }

        private void buttonExportExamClick(object sender, EventArgs e)
        {
            if (!checkBoxExportOriginalImage.Checked && !checkBoxExportEditedImage.Checked)
            {
                MessageBox.Show(Resources.messageExamExportMode);
                return;
            }

            if (pathToExport == "" || pathToExport == null)
            {
                MessageBox.Show(Resources.messageNoPathToExport);
                return;
            }

            eventSaveExportPath?.Invoke(this, EventArgs.Empty);

            string pathComplement = getPathComplement();

            string exportPath = Path.Combine(pathToExport, pathComplement);
            Directory.CreateDirectory(exportPath);

            ImageFormat format = ImageFormat.Bmp;
            string extension = ".bmp";

            switch (comboBoxFormat.InnerControl.SelectedItem)
            {
                case "TIFF":
                    format = ImageFormat.Tiff;
                    extension = ".tiff";
                    break;
                case "JPG":
                    format = ImageFormat.Jpeg;
                    extension = ".jpg";
                    break;
                case "JPEG":
                    format = ImageFormat.Jpeg;
                    extension = ".jpeg";
                    break;
                case "PNG":
                    format = ImageFormat.Png;
                    extension = ".png";
                    break;
                case "DICOM":
                    extension = ".dicom";
                    break;
                case "RAW":
                    extension = ".raw";
                    break;
                        
            }

            List<ImageInfoExport> imagesInfo = getImagesInfoToExport();

            if (waterMark)
            {
                insertWaterMarkOnImages(imagesInfo);
            }

            string fileName;

            if (extension == ".dicom")
            {
                foreach (ImageInfoExport imgInfo in imagesInfo)
                {
                    fileName = $"{Path.GetFileNameWithoutExtension(imgInfo.path)}{extension}";
                    getAndSaveDicomFile(imgInfo.img, Path.Combine(exportPath, fileName));
                }
            }
            else if (extension == ".raw")
            {
                foreach (ImageInfoExport imgInfo in imagesInfo)
                {
                    fileName = $"{Path.GetFileNameWithoutExtension(imgInfo.path)}{extension}";

                    getAndSaveRawFile(imgInfo.img, Path.Combine(exportPath, fileName));
                }
            }
            else
            {
                foreach (ImageInfoExport imgInfo in imagesInfo)
                {
                    fileName = Path.ChangeExtension(Path.GetFileNameWithoutExtension(imgInfo.path), extension);
                    imgInfo.img.Save(Path.Combine(exportPath, fileName));
                }
            }

            MessageBox.Show(Resources.messageExamExportSucess);
            Close();
        }

        private string getPathComplement()
        {

            string patientNameFormatted = Regex.Replace(patientName, @"\s+", "");
            patientNameFormatted = removeAccents(patientNameFormatted);

            return $"{patientNameFormatted}_{DateTime.Now:dd-MM-yyyy-HH-m}";
        }

        private string removeAccents(string texto)
        {
            var normalized = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void insertWaterMarkOnImages(List<ImageInfoExport> imagesInfo)
        {
            foreach (ImageInfoExport imgInfo in imagesInfo)
            {
                bool watermarkOnTopLeft = checkWatermarkCorner(imgInfo.img);

                Bitmap watermark = Resources.watermark;

                PointF p = new PointF(0, 0);

                if (watermarkOnTopLeft)
                {
                    p = new PointF(0, 0);
                }
                else
                {
                    p = new PointF(imgInfo.img.Width - watermark.Width - 40, imgInfo.img.Height - watermark.Height - 40);
                }

                using (Graphics g = Graphics.FromImage(imgInfo.img))
                {
                    g.DrawImage(watermark, p);
                }
            }
        }

        public static bool checkWatermarkCorner(Bitmap image)
        {
            Rectangle topLeft = new Rectangle(0, 0, 100, 100);

            byte threshold = 15;
            long sum = 0;
            int count = 0;

            for (int y = topLeft.Top; y < topLeft.Bottom; y++)
            {
                for (int x = topLeft.Left; x < topLeft.Right; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    sum += pixel.R;
                    count++;
                }
            }

            double average = (double)sum / count;

            return average <= threshold;
        }

        private void getAndSaveDicomFile(Bitmap bitmap, string path)
        {
            byte[] pixelData = convertBitmapToGrayscaleByteArray(bitmap);

            var dataset = new DicomDataset
            {
                { DicomTag.PatientName, patientName },
                { DicomTag.StudyInstanceUID, DicomUIDGenerator.GenerateDerivedFromUUID().UID },
                { DicomTag.SeriesInstanceUID, DicomUIDGenerator.GenerateDerivedFromUUID().UID },
                { DicomTag.SOPInstanceUID, DicomUIDGenerator.GenerateDerivedFromUUID().UID },
                { DicomTag.SOPClassUID, DicomUID.SecondaryCaptureImageStorage },
                { DicomTag.PhotometricInterpretation, PhotometricInterpretation.Monochrome2.Value },
                { DicomTag.Rows, (ushort)bitmap.Height },
                { DicomTag.Columns, (ushort)bitmap.Width },
                { DicomTag.BitsAllocated, (ushort)8 },
                { DicomTag.BitsStored, (ushort)8 },
                { DicomTag.HighBit, (ushort)7 },
                { DicomTag.PixelRepresentation, (ushort)0 },
                { DicomTag.SamplesPerPixel, (ushort)1 }
            };

            dataset.AddOrUpdate(new DicomOtherByte(DicomTag.PixelData, pixelData));

            DicomFile dicomFile = new DicomFile(dataset);
            dicomFile.Save(path);
        }

        private void getAndSaveRawFile(Bitmap bitmap, string path)
        {
            using (Bitmap bmp = new Bitmap(bitmap))
            {
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                int numBytes = bmpData.Stride * bmp.Height;
                byte[] pixelData = new byte[numBytes];

                System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelData, 0, numBytes);

                bmp.UnlockBits(bmpData);

                File.WriteAllBytes(path, pixelData);
            }
        }

        private static byte[] convertBitmapToGrayscaleByteArray(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int bytesPerPixel = Image.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            byte[] pixelData = new byte[width * height * bytesPerPixel];

            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bitmap.PixelFormat);

            try
            {
                IntPtr scan0 = bitmapData.Scan0;
                int stride = bitmapData.Stride;

                for (int y = 0; y < height; y++)
                {
                    IntPtr row = scan0 + (y * stride);
                    System.Runtime.InteropServices.Marshal.Copy(row, pixelData, y * width * bytesPerPixel, width * bytesPerPixel);
                }
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }

            return pixelData;
        }
    }

    class ImageInfoExport
    {
        public int orientation { get; set; }
        public string path { get; set; }
        public Bitmap img { get; set; }

        public ImageInfoExport(int orientation, string path, Bitmap img)
        {
            this.orientation = orientation;
            this.path = path;
            this.img = img;
        }
    }
}