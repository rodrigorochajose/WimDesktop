using DMMDigital.Interface.IView;
using DMMDigital.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class PostProcessConfig : Form, IPostProcessConfig
    {
        public float gamma 
        {
            get { return (float) numericUpDownGamma.Value; }
            set { numericUpDownGamma.Value = (decimal) value; }
        }

        public float edge 
        {
            get { return (float)numericUpDownEdge.Value; }
            set { numericUpDownEdge.Value = (decimal)value; }
        }

        public float noise 
        {
            get { return (float)numericUpDownNoise.Value; }
            set { numericUpDownNoise.Value = (decimal)value; }
        }

        public PostProcessConfig(float gamma, float edge, float noise)
        {
            InitializeComponent();

            this.gamma = gamma;
            this.edge = edge;
            this.noise = noise;

            pictureBoxOriginalImage.Image = Resources.imageConfigFilter;
            pictureBoxFilteredImage.Image = Resources.imageConfigFilter;
        }

        private void buttonImportClick(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image selectedImage = Image.FromStream(openFileDialog1.OpenFile());

                pictureBoxOriginalImage.Image = selectedImage;
                pictureBoxFilteredImage.Image = selectedImage;
            }
        }

        private void buttonApplyClick(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBoxOriginalImage.Image); 

            image = PostProcessFilter.applyFilters(image, new float[] { gamma, edge, noise });

            pictureBoxFilteredImage.Image = image;
            Refresh();
        }

        private void buttonRestoreImageClick(object sender, EventArgs e)
        {
            pictureBoxFilteredImage.Image = new Bitmap(pictureBoxOriginalImage.Image);
        }

        private void buttonRestoreValuesClick(object sender, EventArgs e)
        {
            numericUpDownGamma.Value = 0;
            numericUpDownEdge.Value = 0;
            numericUpDownNoise.Value = 0;
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}