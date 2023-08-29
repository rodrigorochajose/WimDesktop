using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using DMMDigital.Modelos;
using DMMDigital.Views;

namespace DMMDigital
{
    public partial class ManipulateTemplateView : Form, IManipulateTemplateView
    {
        public string templateName { get; set; }
        public List<Frame> frameList { get; set; }

        int framesCounter = 0;
        string nomeDoTemplate;
        Frame selectedFrame;


        public ManipulateTemplateView(string templateName, decimal rows, decimal columns, string orientation)
        {
            InitializeComponent();

            this.templateName = templateName;
            int height, width;

            if (orientation.Contains("Vertical"))
            {
                height = 70;
                width = 50;
            }
            else
            {
                height = 50;
                width = 70;
            }

            for (int rowsCounter = 0, locationY = 50; rowsCounter < rows; rowsCounter++, locationY += height + 10)
            {
                for (int columnsCounter = 0, locationX = 70; columnsCounter < columns; columnsCounter++, locationX += width + 10)
                {
                    framesCounter++;

                    Frame newFrame = new Frame
                    {
                        order = framesCounter,
                        orientation = orientation,
                        Width = width,
                        Height = height,
                        BackColor = Color.Black,
                        Name = "filme" + framesCounter,
                        Location = new Point(locationX, locationY),
                        Tag = Color.Black,
                    };

                    newFrame.MouseDown += filmeClique;
                    newFrame = escreverNaImagem(newFrame);
                    panel2.Controls.Add(novoFilme);
                    ControlExtension.Draggable(novoFilme, true);
                }
            }
        }

        //mudar nome
        private void selecionarFilme(object sender, PaintEventArgs e)
        {
            Frame frame = sender as Frame;
            if ((Color)frame.Tag == Color.Black) 
            { 
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, ButtonBorderStyle.None);
            } 
            else
            {
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid);
            }
        }

        private void filmeClique(object sender, EventArgs e)
        {
            foreach (Frame f in frameList)
            {
                f.Tag = Color.Black;
                f.Paint += selecionarFilme;
                f.Refresh();
            }

            selectedFrame = (Frame)sender;
            filmeAtual.Text = selectedFrame.Name;
            orientacaoAtual.Text = selectedFrame.orientation;
            selectedFrame.Tag = Color.LimeGreen;
            selectedFrame.Paint += selecionarFilme;
            selectedFrame.Refresh();
            
        }

        private void GerarNovoFilme(object sender, EventArgs e)
        {
            framesCounter++;
            Frame newFrame = new Frame
            {
                order = framesCounter,
                Width = 50,
                Height = 70,
                BackColor = Color.Black,
                Name = "frame" + framesCounter
            };

            newFrame.Click += filmeClique;
            newFrame = escreverNaImagem(newFrame);

            frameList.Add(newFrame);
            panel2.Controls.Add(newFrame);
        }

        private Frame escreverNaImagem(Frame frame)
        {
            Bitmap image = new Bitmap(frame.Width, frame.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawString(framesCounter.ToString(), new Font("TimesNewRoman", 20, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, new Point(0, 0));
            frame.Image = image;
            return frame;
        }

        private void SalvarTemplate(object sender, EventArgs e)
        {
            Contexto<TemplateModel> template = new Contexto<TemplateModel>();
            Contexto<TemplateLayoutModel> templateLayout = new Contexto<TemplateLayoutModel>();


            TemplateModel newTemplate = new TemplateModel()
            {
                name = nomeDoTemplate
            };

            template.tabela.Add(newTemplate);
            template.SaveChanges();

            int idTemplate = newTemplate.id;

            foreach (Frame f in frameList)
            {
                TemplateLayoutModel newTemplateLayout = new TemplateLayoutModel()
                {
                    templateId = idTemplate,
                    locationX = f.Location.X,
                    locationY = f.Location.Y,
                    orientation = f.orientation,
                    order = f.order,
                };
                templateLayout.tabela.Add(newTemplateLayout);
            }

            templateLayout.SaveChanges();
            MessageBox.Show("Template Salvo com sucesso!");
            this.Close();
        }

        private void ExcluirFilme(object sender, EventArgs e)
        {
            framesCounter--;
            frameList.Remove(selectedFrame);
            panel2.Controls.Remove(selectedFrame);
        }

        private void botaoGirarFilmeEsquerdaClique(object sender, EventArgs e)
        {
            switch (selectedFrame.orientation)
            {
                case "Vertical Cima":
                    selectedFrame.orientation = "Horizontal Esquerda";
                    break;

                case "Horizontal Esquerda":
                    selectedFrame.orientation = "Vertical Baixo";
                    break;

                case "Vertical Baixo":
                    selectedFrame.orientation = "Horizontal Direita";
                    break;

                case "Horizontal Direita":
                    selectedFrame.orientation = "Vertical Cima";
                    break;
            }


            (selectedFrame.Width, selectedFrame.Height) = (selectedFrame.Height, selectedFrame.Width);
            orientacaoAtual.Text = selectedFrame.orientation;
            selectedFrame.Refresh();
        }

        private void botaoGirarFilmeDireitaClique(object sender, EventArgs e)
        {
            switch (selectedFrame.orientation)
            {
                case "Vertical Cima":
                    selectedFrame.orientation = "Horizontal Direita";
                    break;

                case "Horizontal Esquerda":
                    selectedFrame.orientation = "Vertical Cima";
                    break;

                case "Vertical Baixo":
                    selectedFrame.orientation = "Horizontal Esquerda";
                    break;

                case "Horizontal Direita":
                    selectedFrame.orientation = "Vertical Baixo";
                    break;
            }

            (selectedFrame.Width, selectedFrame.Height) = (selectedFrame.Height, selectedFrame.Width);
            orientacaoAtual.Text = selectedFrame.orientation;
            selectedFrame.Refresh();
        }
    }
}

