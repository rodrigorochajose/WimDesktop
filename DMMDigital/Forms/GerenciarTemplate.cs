using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Modelos;

namespace DMMDigital
{
    public partial class GerenciarTemplate : Form
    {
        int contadorDeFilmes = 0;
        string nomeDoTemplate;
        Filme filmeSelecionado;

        public GerenciarTemplate(string nomeDoTemplate, decimal linhas, decimal colunas, string orientacao)
        {
            InitializeComponent();


            this.nomeDoTemplate = nomeDoTemplate;
            int altura, largura;

            if (orientacao.Contains("Vertical"))
            {
                altura = 70;
                largura = 50;
            }
            else
            {
                altura = 50;
                largura = 70;
            }

            for (int contadorLinhas = 0, posicaoFrameY = 50; contadorLinhas < linhas; contadorLinhas++, posicaoFrameY += altura + 10)
            {
                for (int contadorColunas = 0, posicaoFrameX = 70; contadorColunas < colunas; contadorColunas++, posicaoFrameX += largura + 10)
                {
                    contadorDeFilmes++;

                    Filme novoFilme = new Filme
                    {
                        Ordem = contadorDeFilmes,
                        Orientacao = orientacao,
                        Width = largura,
                        Height = altura,
                        BackColor = Color.Black,
                        Name = "filme" + contadorDeFilmes,
                        Location = new Point(posicaoFrameX, posicaoFrameY),
                        Tag = Color.Black,
                    };

                    novoFilme.MouseDown += filmeClique;
                    novoFilme = escreverNaImagem(novoFilme, contadorDeFilmes);
                    panel2.Controls.Add(novoFilme);
                    ControlExtension.Draggable(novoFilme, true);
                }
            }
        }


        private void selecionarFilme(object sender, PaintEventArgs e)
        {
            Filme filme = (Filme)sender;
            if ((Color)filme.Tag == Color.Black) 
            { 
                ControlPaint.DrawBorder(e.Graphics, filme.ClientRectangle, (Color)filme.Tag, ButtonBorderStyle.None);
            } 
            else
            {
                ControlPaint.DrawBorder(e.Graphics, filme.ClientRectangle, (Color)filme.Tag, 3, ButtonBorderStyle.Solid, (Color)filme.Tag, 3, ButtonBorderStyle.Solid, (Color)filme.Tag, 3, ButtonBorderStyle.Solid, (Color)filme.Tag, 3, ButtonBorderStyle.Solid);
            }
        }

        private void filmeClique(object sender, EventArgs e)
        {
            IEnumerable<Filme> listaFilmes = panel2.Controls.Cast<Filme>();

            foreach (Filme fm in listaFilmes)
            {
                fm.Tag = Color.Black;
                fm.Paint += selecionarFilme;
                fm.Refresh();
            }

            filmeSelecionado = (Filme)sender;
            filmeAtual.Text = filmeSelecionado.Name;
            orientacaoAtual.Text = filmeSelecionado.Orientacao;
            filmeSelecionado.Tag = Color.LimeGreen;
            filmeSelecionado.Paint += selecionarFilme;
            filmeSelecionado.Refresh();
            
        }

        private void GerarNovoFilme(object sender, EventArgs e)
        {
            contadorDeFilmes++;
            Filme novoFrame = new Filme
            {
                Ordem = contadorDeFilmes,
                Width = 50,
                Height = 70,
                BackColor = Color.Black,
                Name = "frame" + contadorDeFilmes
            };

            novoFrame.Click += filmeClique;
            novoFrame = escreverNaImagem(novoFrame, contadorDeFilmes);

            panel2.Controls.Add(novoFrame);
        }

        private Filme escreverNaImagem(Filme novoFilme, int contadorDeFrames)
        {
            var image = new Bitmap(novoFilme.Width, novoFilme.Height);
            var font = new Font("TimesNewRoman", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(contadorDeFrames.ToString(), font, Brushes.White, new Point(0, 0));
            novoFilme.Image = image;
            return novoFilme;
        }

        private void SalvarTemplate(object sender, EventArgs e)
        {
            Contexto<TemplateModel> template = new Contexto<TemplateModel>();
            Contexto<TemplateLayoutModel> templateLayout = new Contexto<TemplateLayoutModel>();

            IEnumerable<Filme> listaFilmes = panel2.Controls.OfType<Filme>();

            TemplateModel novoTemplate = new TemplateModel()
            {
                nome = nomeDoTemplate
            };

            template.tabela.Add(novoTemplate);
            template.SaveChanges();

            int idTemplate = novoTemplate.id;

            foreach (Filme filme in listaFilmes)
            {
                TemplateLayoutModel novoTemplateLayout = new TemplateLayoutModel()
                {
                    templateID = idTemplate,
                    posicaoX = filme.Location.X,
                    posicaoY = filme.Location.Y,
                    orientacao = filme.Orientacao,
                    ordem = filme.Ordem,
                };
                templateLayout.tabela.Add(novoTemplateLayout);
            }

            templateLayout.SaveChanges();
            MessageBox.Show("Template Salvo com sucesso!");
            this.Close();
        }

        private void ExcluirFilme(object sender, EventArgs e)
        {
            contadorDeFilmes--;
            panel2.Controls.Remove(filmeSelecionado);
        }

        private void botaoGirarFilmeEsquerdaClique(object sender, EventArgs e)
        {
            if (filmeSelecionado.Orientacao == "Vertical Cima")
            {
                filmeSelecionado.Orientacao = "Horizontal Esquerda";
            } 
            else if (filmeSelecionado.Orientacao == "Horizontal Esquerda")
            {
                filmeSelecionado.Orientacao = "Vertical Baixo";
            }
            else if (filmeSelecionado.Orientacao == "Vertical Baixo")
            {
                filmeSelecionado.Orientacao = "Horizontal Direita";
            } else
            {
                filmeSelecionado.Orientacao = "Vertical Cima";
            }

            (filmeSelecionado.Width, filmeSelecionado.Height) = (filmeSelecionado.Height, filmeSelecionado.Width);
            orientacaoAtual.Text = filmeSelecionado.Orientacao;
            filmeSelecionado.Refresh();
        }

        private void botaoGirarFilmeDireitaClique(object sender, EventArgs e)
        {
            if (filmeSelecionado.Orientacao == "Vertical Cima")
            {
                filmeSelecionado.Orientacao = "Horizontal Direita";
            }
            else if (filmeSelecionado.Orientacao == "Horizontal Direita")
            {
                filmeSelecionado.Orientacao = "Vertical Baixo";
            }
            else if (filmeSelecionado.Orientacao == "Vertical Baixo")
            {
                filmeSelecionado.Orientacao = "Horizontal Esquerda";
            }
            else
            {
                filmeSelecionado.Orientacao = "Vertical Cima";
            }
            (filmeSelecionado.Width, filmeSelecionado.Height) = (filmeSelecionado.Height, filmeSelecionado.Width);
            orientacaoAtual.Text = filmeSelecionado.Orientacao;
            filmeSelecionado.Refresh();
        }
    }
}

