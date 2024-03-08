using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Aspose.Imaging.ImageOptions;
using DMMDigital.Components;

namespace DMMDigital.Views
{
    public partial class ExportExamView : Form, IExportExamView
    {
        public string patientName { get; set; }
        public string pathImages { get; set; }
        public string pathToExport { get; set; }
        public List<Frame> framesToExport { get; set; }

        public ExportExamView()
        {
            InitializeComponent();

            comboBoxFormat.SelectedIndex = 0;

            buttonCancel.Click += delegate { Close(); };
        }

        private void exportExamViewLoad(object sender, EventArgs e)
        {
            loadExamFrames();
            pathToExport = folderBrowserDialog1.SelectedPath;
            textBox1.Text = folderBrowserDialog1.SelectedPath;

            textBox1.Click += selectPath;
            button1.Click += selectPath;
        }

        public void loadExamFrames()
        {
            IEnumerable<Frame> framesToDraw = framesToExport.Where(f => f.originalImage != null);

            foreach (Frame frame in framesToDraw)
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

                if (frame.orientation.Contains("Horizontal"))
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
                    Text = $"Template - Filme {frame.order}"
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

                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        public void selectPath(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();         
            pathToExport = folderBrowserDialog1.SelectedPath;
            textBox1.Text = folderBrowserDialog1.SelectedPath;
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

        private void buttonExportExamClick(object sender, EventArgs e)
        {
            if (!checkBoxExportOriginalImage.Checked && !checkBoxExportEditedImage.Checked)
            {
                MessageBox.Show("Selecione como deseja exportar a imagem!");
            }
            else
            {
                string path = Path.Combine(pathToExport, $"{patientName}_{DateTime.Now:dd-MM-yyyy-HH-m}");
                Directory.CreateDirectory(path);

                ImageFormat format = ImageFormat.Bmp;
                string extension = ".bmp";

                List<string> files = new List<string>();

                List<CheckBox> checkBoxes = getAllFrameCheckBox().Where(cb => cb.Checked).ToList();
                
                switch (comboBoxFormat.SelectedItem)
                {
                    case "TIFF":
                        format = ImageFormat.Tiff;
                        extension = ".tiff";
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
                        
                }

                if (checkBoxExportOriginalImage.Checked)
                {
                    foreach (CheckBox cb in checkBoxes)
                    {
                        files.Add(Path.Combine(pathImages, $"{cb.Tag}-original.png"));
                    }
                }

                if (checkBoxExportEditedImage.Checked)
                {
                    foreach (CheckBox cb in checkBoxes)
                    {
                        generateEditedImage(cb.Tag.ToString(), pathImages, format, extension);
                        files.Add(Path.Combine(pathImages, $"{cb.Tag}-edited{extension}"));
                    }
                }

                if (extension == ".dicom")
                {
                    foreach (string file in files)
                    {
                        Bitmap bmp = new Bitmap(file);

                        using (MemoryStream stream = new MemoryStream())
                        {
                            bmp.Save(stream, ImageFormat.Bmp);
                            stream.Position = 0;
                            Aspose.Imaging.Image imageAspose = Aspose.Imaging.Image.Load(stream);
                            DicomOptions exportOptions = new DicomOptions();
                            imageAspose.Save(Path.Combine(path, $"{Path.GetFileNameWithoutExtension(file)}{extension}"), exportOptions);
                        }
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

                MessageBox.Show("Exportado com sucesso!");
                Close();
            }
        }

        private void generateEditedImage(string frameId, string path, ImageFormat format, string extension)
        {
            string originalFileName = $"{frameId}-original.png";
            string editedFileName = $"{frameId}-edited{extension}";

            Bitmap mainImage = new Bitmap(Path.Combine(path, originalFileName));

            List<string> imageDrawings = Directory.GetFiles(path).Where(f => f.Contains($"F{frameId}-")).ToList();

            using (Graphics graphics = Graphics.FromImage(mainImage))
            {
                foreach (string drawing in imageDrawings)
                {
                    graphics.DrawImage(new Bitmap(drawing), 0, 0, mainImage.Width, mainImage.Height);
                }
            }

            mainImage.Save(Path.Combine(path, editedFileName), format);
        }

        private List<CheckBox> getAllFrameCheckBox()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Panel panel in flowLayoutPanel1.Controls.OfType<Panel>())
            {
                checkBoxes.Add(panel.Controls.OfType<CheckBox>().First());
            }
            return checkBoxes;
        }
    }
}
