using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using MoreLinq;
using DMMDigital.Interface.IView;

namespace DMMDigital.Views
{
    public partial class RecycleBinView : Form, IRecycleBinView
    {
        public Image imageToRestore { get; set; }

        private string path;
        private Panel selectedPanel = null;

        public RecycleBinView(string path)
        {
            InitializeComponent();
            this.path = path;

            associateEvents();

            loadImages();
        }

        private void associateEvents()
        {
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    restoreImage();
                }
                else if (e.KeyChar == (char)Keys.Escape)
                {
                    Close();
                    DialogResult = DialogResult.Cancel;
                }
            };

            buttonRestoreImage.Click += delegate { restoreImage(); };
        }

        private void loadImages()
        {
            Regex regex = new Regex(@"^\d+");

            var files = Directory.GetFiles(path)
                .Where(file => Path.GetFileNameWithoutExtension(file).Contains("original"))
                .OrderBy(file =>
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    Match match = regex.Match(fileName);
                    return match.Success ? int.Parse(match.Value) : int.MaxValue;
                })
                .Select(file => new { Name = Path.GetFileNameWithoutExtension(file), FullPath = file })
                .ToList();

            foreach (var file in files)
            {
                Bitmap bmp = new Bitmap(file.FullPath);

                Panel panel = new Panel
                {
                    Size = new Size(230, 300),
                    Padding = new Padding(10, 5, 10, 5),
                    BackColor = Color.FromArgb(224, 224, 224)
                };

                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Image = bmp
                };

                pictureBox.Click += selectImage;

                panel.Controls.Add(pictureBox);

                FlowLayoutPanel panelLabel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Bottom,
                    Size = new Size(230, 50),
                    FlowDirection = FlowDirection.TopDown
                };

                string[] fileNameParts = file.Name.Split('_');

                Label labelImageName = new Label
                {
                    Width = pictureBox.Width,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Text = $"{fileNameParts[0]}_{fileNameParts[1]}"
                };

                panelLabel.Controls.Add(labelImageName);

                Label labelDeletedDate = new Label
                {
                    Width = pictureBox.Width,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Text = $"{fileNameParts[2].Replace('-', '\\')} {fileNameParts[3].Replace('-', ':')}"
                };

                panelLabel.Controls.Add(labelDeletedDate);

                panel.Controls.Add(panelLabel);
                flowLayoutPanel.Controls.Add(panel);
            }
        }

        private void selectImage(object sender, EventArgs e)
        {
            Panel clickedPanel = (sender as Control).Parent as Panel;

            if (clickedPanel == selectedPanel)
            {
                clickedPanel.BackColor = Color.FromArgb(224, 224, 224);
                selectedPanel = null;
            }
            else
            {
                if (selectedPanel != null)
                {
                    selectedPanel.BackColor = Color.FromArgb(224, 224, 224);
                }

                clickedPanel.BackColor = Color.White;
                selectedPanel = clickedPanel;
            }

            clickedPanel.Refresh();
            selectedPanel?.Refresh();
        }
    
        private void restoreImage()
        {
            PictureBox pb = selectedPanel.Controls.OfType<PictureBox>().First();

            imageToRestore = pb.Image;

            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
