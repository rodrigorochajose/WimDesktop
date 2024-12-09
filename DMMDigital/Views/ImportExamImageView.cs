using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class ImportExamImageView : Form, IImportExamImageView
    {
        public int patientId { get; set; }
        public int examId { get; set; }
        public List<ExamModel> exams { get; set; }
        public List<string> imageFiles { get; set; }

        public event EventHandler eventGetExamImages;

        List<Image> selectedImages = new List<Image>();

        string selectionMode = "";

        public ImportExamImageView(string selectionMode)
        {
            InitializeComponent();

            this.selectionMode = selectionMode;

            associateEvents();
        }

        private void associateEvents()
        {
            Load += delegate
            {
                loadImages();

                dataGridViewExam.SelectionChanged += delegate
                {
                    if (dataGridViewExam.SelectedRows.Count > 0)
                    {
                        examId = int.Parse(dataGridViewExam.Rows[dataGridViewExam.SelectedCells[0].RowIndex].Cells["columnExamId"].Value.ToString());
                        flowLayoutPanel.Controls.Clear();
                        loadImages();
                    }
                };
            };

            buttonCancel.Click += delegate { Close(); };

            buttonSelect.Click += delegate 
            {
                setSelectedImages();

                if (!selectedImages.Any())
                {
                    MessageBox.Show(Resources.messageImageNotSelected);
                    return;
                }

                Close();
            };
        }

        public void setExamList(BindingSource examList)
        {
            dataGridViewExam.DataSource = examList;
        }

        private void loadImages()
        {
            eventGetExamImages?.Invoke(this, EventArgs.Empty);

            for (int counter = 0; counter < imageFiles.Count; counter++)
            {
                Panel panel = new Panel
                {
                    Name = $"panel{counter}",
                    Location = new Point(3, 3),
                    Size = new Size(150, 95),
                };

                panel.HorizontalScroll.Enabled = false;
                panel.HorizontalScroll.Visible = false;

                CheckBox checkBox = new CheckBox
                {
                    Name = $"checkBox{counter}",
                    Location = new Point(20, 35),
                    Size = new Size(20, 20),
                    UseVisualStyleBackColor = true
                };

                if (selectionMode == "single")
                {
                    checkBox.CheckedChanged += (s, e) =>
                    {
                        if (checkBox.Checked)
                        {
                            foreach (Panel p in flowLayoutPanel.Controls.OfType<Panel>())
                            {
                                CheckBox otherCheckBox = p.Controls.OfType<CheckBox>().FirstOrDefault();
                                if (otherCheckBox != null && otherCheckBox != checkBox)
                                {
                                    otherCheckBox.Checked = false;
                                }
                            }
                        }
                    };
                }

                PictureBox pictureBox = new PictureBox
                {
                    Name = $"pictureBox{counter}",
                    Location = new Point(65, 10),
                    Size = new Size(60, 85)
                };

                Image img = Image.FromFile(imageFiles[counter]);

                checkBox.Tag = img;

                if (img.Width > img.Height)
                {
                    pictureBox.Size = new Size(85, 60);
                }

                pictureBox.Image = img.GetThumbnailImage(pictureBox.Width, pictureBox.Height, () => false, IntPtr.Zero);

                panel.Controls.Add(checkBox);
                panel.Controls.Add(pictureBox);

                flowLayoutPanel.Controls.Add(panel);
            }
        }

        private void setSelectedImages()
        {
            List<CheckBox> checkBoxes = getCheckedsCheckBox();

            foreach (CheckBox cb in checkBoxes)
            {
                selectedImages.Add((Image)cb.Tag);
            }
        }

        private List<CheckBox> getCheckedsCheckBox()
        {
            List<CheckBox> checkBoxes = new List<CheckBox>();
            foreach (Panel panel in flowLayoutPanel.Controls.OfType<Panel>())
            {
                checkBoxes.AddRange(panel.Controls.OfType<CheckBox>().Where(c => c.Checked == true));
            }
            return checkBoxes;
        }

        public List<Image> getSelectedImages()
        {
            return selectedImages;
        }
    }
}
