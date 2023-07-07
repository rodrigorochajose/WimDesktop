using GeraçãoDeTemplate.Modelos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GeraçãoDeTemplate.Forms
{
    public partial class PacienteExame : Form
    {
        Contexto<Paciente> contexto = new Contexto<Paciente>();
        
        public PacienteExame()
        {
            InitializeComponent();
        }

        private void PacienteExameCarregar(object sender, EventArgs e)
        {
            tabelaPacienteExame.DataSource = contexto.tabela.Select(t => new { t.id, t.nome, t.data_nascimento, t.telefone }).ToList();
        }

        private void botaoSelecionarPacienteExameClique(object sender, EventArgs e)
        {
            int idPaciente = Int32.Parse(tabelaPacienteExame.Rows[tabelaPacienteExame.CurrentCell.RowIndex].Cells[0].Value.ToString());
            TemplateExame novoForm = new TemplateExame(idPaciente);
            novoForm.MdiParent = this.MdiParent;
            novoForm.Show();
            this.Close();

        }

        private void botaoNovoPacienteClique(object sender, EventArgs e)
        {
            NovoPaciente novoForm = new NovoPaciente();
            novoForm.ShowDialog();
            tabelaPacienteExame.DataSource = contexto.tabela.Select(t => new { t.id, t.nome, t.data_nascimento, t.telefone }).ToList();
        }
    }
}
