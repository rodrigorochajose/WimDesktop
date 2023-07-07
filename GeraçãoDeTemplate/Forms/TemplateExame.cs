using GeraçãoDeTemplate.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GeraçãoDeTemplate.Forms
{
    public partial class TemplateExame : Form
    {
        Contexto<Template> contextoTemplate = new Contexto<Template>();
        Paciente pacienteExame = null;
        List<TemplateLayout> listaTemplateLayout = null;
        public TemplateExame(int idPaciente)
        {
            InitializeComponent();

            Contexto<Paciente> contextoPaciente = new Contexto<Paciente>();

            pacienteExame = contextoPaciente.tabela.Find(idPaciente);
            textBoxNome.Text = pacienteExame.nome;
            textBoxDataNascimento.Text = pacienteExame.data_nascimento.ToString();
            textBoxTelefone.Text = pacienteExame.telefone;
            textBoxIndicacao.Text = pacienteExame.indicacao;
            textBoxObservacao.Text = pacienteExame.observacao;

            comboBox1.DataSource = contextoTemplate.tabela.ToList();
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";

        }

        private void novoTemplateClique(object sender, EventArgs e)
        {
            GeracaoTemplate novoForm = new GeracaoTemplate();
            novoForm.ShowDialog();

            comboBox1.DataSource = contextoTemplate.tabela.ToList();
        }

        private void selecionaTemplate(object sender, EventArgs e)
        {
            limparTemplate();
            
            Contexto<TemplateLayout> contextoTemplateLayout = new Contexto<TemplateLayout>();

            int templateId = int.Parse(comboBox1.SelectedValue.ToString());
            int altura = 0, largura = 0;

            listaTemplateLayout = contextoTemplateLayout.tabela.Where(ctl => ctl.templateID == templateId).ToList();

            foreach (TemplateLayout tl in listaTemplateLayout)
            {
                if (tl.orientacao == "Vertical")
                {
                    altura = 35;
                    largura = 25;
                }
                else
                {
                    altura = 25;
                    largura = 35;
                }

                PictureBox novoFilme = new PictureBox
                {
                    Width = largura,
                    Height = altura,
                    BackColor = Color.Black,
                };


                Bitmap image = new Bitmap(novoFilme.Width, novoFilme.Height);
                Graphics graphics = Graphics.FromImage(image);
                Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                graphics.DrawString(tl.ordem.ToString(), font, Brushes.White, new Point(0, 0));
                novoFilme.Image = image;
                novoFilme.Location = new Point(tl.posicaoX / 2, tl.posicaoY / 2);

                panel3.Controls.Add(novoFilme);
            }
        }

        private void limparTemplate()
        {
            List<PictureBox> painel = this.panel3.Controls.Cast<PictureBox>().ToList();

            if (painel != null)
            {
                foreach (PictureBox pb in painel)
                {
                    this.panel3.Controls.Remove(pb);
                }
            }
        }

        private void botaoIniciarRadiografiaClique(object sender, EventArgs e)
        {
            Exame novoForm = new Exame(pacienteExame, listaTemplateLayout, comboBox1.Text, textBox1.Text);
            novoForm.Show();
            Close();
        }
    }
}
