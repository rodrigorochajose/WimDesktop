using GeraçãoDeTemplate.Forms;
using GeraçãoDeTemplate.Modelos;
using System;
using System.Windows.Forms;

namespace GeraçãoDeTemplate
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void botaoNovoExameClique(object sender, EventArgs e)
        {
            PacienteExame novoForm = new PacienteExame();
            novoForm.MdiParent = this;
            novoForm.Show();
        }

        private void botaoPacienteClique(object sender, EventArgs e)
        {
            Pacientes novoForm = new Pacientes();
            novoForm.MdiParent = this;
            novoForm.Show();
        }

        private void botaoConfiguracoesClique(object sender, EventArgs e)
        {
            Configuracoes novoForm = new Configuracoes();
            novoForm.Show();
        }
    }
}
