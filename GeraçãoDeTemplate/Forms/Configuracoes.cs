using GeraçãoDeTemplate.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeraçãoDeTemplate.Forms
{
    public partial class Configuracoes : Form
    {
        Contexto<Configuracao> contexto = new Contexto<Configuracao>();
        
        public Configuracoes()
        {
            InitializeComponent();

            List<Configuracao> config = contexto.tabela.ToList();

            if (config.Count() != 0)
            {
                textBoxCaminho.Text = config.First().caminho_radiografia.ToString();
            }
        }

        private void textBoxCaminhoClique(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxCaminho.Text = folderBrowserDialog1.SelectedPath;
        }

        private void botaoSalvarClique(object sender, EventArgs e)
        {

            Configuracao config = new Configuracao()
            {
                caminho_radiografia = textBoxCaminho.Text
            };

            contexto.tabela.Add(config);
            contexto.SaveChanges();

            MessageBox.Show("Caminho salvo !");
            Close();
        }

    }
}
