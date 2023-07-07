using System;
using System.Windows.Forms;

namespace GeraçãoDeTemplate
{
    public partial class GeracaoTemplate : Form
    {
        public GeracaoTemplate()
        {
            InitializeComponent();
        }

        private void GerarTemplate(object sender, EventArgs e)
        {
            string nomeDoTemplate = this.nomeDoTemplate.Text;
            var linhas = quantidadeLinhas.Value;
            var colunas = quantidadeColunas.Value;
            string orientacao = this.orientacao.Text;

            GerenciarTemplate novoForm = new GerenciarTemplate(nomeDoTemplate, linhas, colunas, orientacao);
            novoForm.ShowDialog();
            this.Close();
        }
    }
}
