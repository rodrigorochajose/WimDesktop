using DMMDigital.Interface.IView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Components;
using DMMDigital.Models;
using FellowOakDicom.Imaging;
using FellowOakDicom;
using DMMDigital.Properties;

namespace DMMDigital.Views
{
    public partial class ExportExamView : Form, IExportExamView
    {
        public string patientName { get; set; }
        public string pathImages { get; set; }
        public string pathToExport { get; set; }
        public List<Frame> framesToExport { get; set; }
        public List<ExamImageDrawingModel> examImageDrawings { get; set; }

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

            textBoxSelectPath.Text = pathToExport;

            textBoxSelectPath.Click += selectPath;
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

                PictureBox pictureBox = new PictureBox { 
                    Name = $"pictureBoxFrame{frame.order}",
                    Location = new Point(20, 5),
                    Size = new Size(60, 85)
                };

                if (frame.orientation > 1)
                {
                    pictureBox.Location = new Point(17, 10);
                    pictureBox.Size = new Size(85, 60);
                }

                pictureBox.Image = frame.Image.GetThumbnailImage(pictureBox.Width, pictureBox.Height, () => false, IntPtr.Zero);

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

                panel.Controls.Add(checkBox);
                panel.Controls.Add(label);
                panel.Controls.Add(pictureBox);

                flowLayoutPanel.Controls.Add(panel);
            }
        }

        public void selectPath(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();         
            pathToExport = folderBrowserDialog1.SelectedPath;
            textBoxSelectPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void checkBoxSelectAllMouseCaptureChanged(object sender, EventArgs e)
        {
            if (checkBoxClearSelection.Checked)
            {
                checkBoxClearSelection.Checked = false;
            }

            foreach (CheckBox cb in getAllFrameCheckBox())
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

            foreach (CheckBox cb in getAllFrameCheckBox())
            {
                cb.Checked = false;
            }

            checkBoxClearSelection.Checked = true;
        }

        private List<CheckBox> getAllFrameCheckBox()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Panel panel in flowLayoutPanel.Controls.OfType<Panel>())
            {
                checkBoxes.AddRange(panel.Controls.OfType<CheckBox>().Where(c => c.Checked == true));
            }

            return checkBoxes;
        }

        private void buttonExportExamClick(object sender, EventArgs e)
        {
            if (!checkBoxExportOriginalImage.Checked && !checkBoxExportEditedImage.Checked)
            {
                MessageBox.Show(Resources.messageExamExportMode);
            }
            else
            {
                eventSaveExportPath?.Invoke(this, EventArgs.Empty);

                string path = Path.Combine(pathToExport, $"{patientName}_{DateTime.Now:dd-MM-yyyy-HH-m}");
                Directory.CreateDirectory(path);

                ImageFormat format = ImageFormat.Bmp;
                string extension = ".bmp";

                List<string> files = new List<string>();

                List<CheckBox> checkBoxes = getAllFrameCheckBox();
                
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

                if (checkBoxExportOriginalImage.Checked)
                {
                    foreach (CheckBox cb in checkBoxes)
                    {
                        files.Add(Path.Combine(pathImages, $"{cb.Tag}_original.png"));
                    }
                }

                if (checkBoxExportEditedImage.Checked)
                {
                    foreach (CheckBox cb in checkBoxes)
                    {
                        string currentImagePath = Path.Combine(pathImages, $"{cb.Tag}_edited.png");

                        if (File.Exists(currentImagePath))
                        {
                            files.Add(currentImagePath);
                        }
                    }
                }

                if (extension == ".dicom")
                {
                    foreach (string file in files)
                    {
                        Bitmap bmp = new Bitmap(file);
                        getAndSaveDicomFile(bmp, Path.Combine(path, $"{Path.GetFileNameWithoutExtension(file)}{extension}"));
                    }
                }
                else if (extension == ".raw")
                {
                    foreach (string file in files)
                    {
                        Bitmap bmp = new Bitmap(file);
                        getAndSaveRawFile(bmp, Path.Combine(path, $"{Path.GetFileNameWithoutExtension(file)}{extension}"));
                    }
                }
                else
                {
                    foreach (string file in files)
                    {
                        Bitmap imageToExport = new Bitmap(file);
                        string fileName = Path.ChangeExtension(Path.GetFileNameWithoutExtension(file), extension);
                        imageToExport.Save(Path.Combine(path, fileName));
                    }
                }

                MessageBox.Show(Resources.messageExamExportSucess);
                Close();
            }
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
}
