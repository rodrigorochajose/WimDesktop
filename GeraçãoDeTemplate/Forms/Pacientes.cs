using GeraçãoDeTemplate.Modelos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GeraçãoDeTemplate.Forms
{
    public partial class Pacientes : Form
    {

        Contexto<Paciente> contexto = new Contexto<Paciente>();

        public Pacientes()
        {
            InitializeComponent();
        }

        private void FormPacientesCarregar(object sender, EventArgs e)
        {
            tabelaPacientes.DataSource = contexto.tabela.Select(t => new {t.id, t.nome, t.data_nascimento, t.telefone }).ToList();
        }

        private void criarNovoPaciente(object sender, EventArgs e)
        {
            NovoPaciente novoFormFilho = new NovoPaciente();
            novoFormFilho.MdiParent = this.MdiParent;
            novoFormFilho.Show();
            this.Close();
        }

        private void botaoCancelarClique(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buscarPacienteTextoAlterado(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            tabelaPacientes.DataSource = dt;
            (tabelaPacientes.DataSource as DataTable).DefaultView.RowFilter = string.Format("Nome = '{0}'", buscarPaciente.Text);
        }

        private void colunasAcoesClique(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int idPaciente = Int32.Parse(this.tabelaPacientes.Rows[e.RowIndex].Cells["id"].Value.ToString());
                EditarPaciente novoFormFilho = new EditarPaciente(idPaciente);
                novoFormFilho.ShowDialog();

                tabelaPacientes.DataSource = contexto.tabela.Select(t => new { t.id, t.nome, t.data_nascimento, t.telefone }).ToList();

            } 
            else if (e.ColumnIndex == 1 && e.RowIndex != -1)
            {
                int idPaciente = Int32.Parse(this.tabelaPacientes.Rows[e.RowIndex].Cells["id"].Value.ToString());
                Paciente paciente = contexto.tabela.Find(idPaciente);
                
                DialogResult confirmacao = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult.Yes.Equals(confirmacao))
                {
                    contexto.tabela.Remove(paciente);
                    contexto.SaveChanges();
                }

                tabelaPacientes.DataSource = contexto.tabela.Select(t => new { t.id, t.nome, t.data_nascimento, t.telefone }).ToList();
            }
        }
    }
}
