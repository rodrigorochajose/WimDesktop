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
                }
            };

            buttonRestoreImage.Click += delegate { restoreImage(); };
        }

        private void loadImages()
        {
            Regex regex = new Regex(@"^\d+");

            var files = Directory.GetFiles(path)
                .AsEnumerable()
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
                Image img = Image.FromFile(file.FullPath);

                Panel panel = new Panel
                {
                    Size = new Size(230, 300),
                    Padding = new Padding(10, 15, 10, 10),
                    BackColor = Color.FromArgb(224, 224, 224)
                };

                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    Image = img
                };

                pictureBox.Click += selectImage;

                Panel panelLabel = new Panel
                {
                    Dock = DockStyle.Bottom,
                    Size = new Size(230, 20)
                };

                Label label = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    Text = file.Name.Split('-')[0]
                };

                panelLabel.Controls.Add(label);

                label.Left = (panelLabel.Width - label.Width) / 2;

                panel.Controls.Add(pictureBox);
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
        }
    }
}
