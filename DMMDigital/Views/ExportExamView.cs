using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Components;

namespace DMMDigital.Views
{
    public partial class ExportExamView : Form, IExportExamView
    {
        public string sessionName { get; set; }
        public string pathImages { get; set; }
        public string pathToExport { get; set; }
        public List<Frame> framesToExport { get; set; }

        public ExportExamView()
        {
            InitializeComponent();

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

        private void checkBoxSelectAll_MouseCaptureChanged(object sender, EventArgs e)
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

        private void checkBoxClearSelection_MouseCaptureChanged(object sender, EventArgs e)
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
                List<CheckBox> checkBoxes = getAllFrameCheckBox().Where(cb => cb.Checked).ToList();

                List<string> files = new List<string>();

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
                        files.Add(Path.Combine(pathImages, $"{cb.Tag}-edited.png"));
                    }
                }

                Directory.CreateDirectory(Path.Combine(pathToExport, sessionName));

                foreach (string file in files)
                {     
                    File.Copy(file, Path.Combine(Path.Combine(pathToExport, sessionName), Path.GetFileName(file)));
                }

                if (checkBoxZip.Checked)
                {
                    ZipFile.CreateFromDirectory(Path.Combine(pathToExport, sessionName), Path.Combine(pathToExport, $"{sessionName}.zip"));
                    Directory.Delete(Path.Combine(pathToExport, sessionName), true);
                }

                MessageBox.Show("Exportado com sucesso!");
                Close();
            }
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
