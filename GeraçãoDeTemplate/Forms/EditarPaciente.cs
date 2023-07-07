using GeraçãoDeTemplate.Modelos;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GeraçãoDeTemplate.Forms
{
    public partial class EditarPaciente : Form
    {
        Contexto<Paciente> contexto = new Contexto<Paciente>();
        Paciente paciente;
        public EditarPaciente(int idPaciente)
        {
            paciente = contexto.tabela.Where(t => t.id == idPaciente).Single();

            InitializeComponent();

            txtNome.Text = paciente.nome;
            dataNascimento.Text = paciente.data_nascimento.ToString();
            txtTelefone.Text = paciente.telefone;
            txtIndicacao.Text = paciente.indicacao;
            txtObservacao.Text = paciente.observacao;
        }
        private void botaoAtualizarPacienteClique(object sender, EventArgs e)
        {
            paciente.nome = txtNome.Text;
            paciente.data_nascimento = DateTime.Parse(dataNascimento.Text);
            paciente.telefone = txtTelefone.Text;
            paciente.indicacao = txtIndicacao.Text;
            paciente.observacao = txtObservacao.Text;

            try
            {
                contexto.SaveChanges();
                MessageBox.Show("Paciente Atualizado com sucesso !");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro.");
            }


        }

        private void botaoCancelarClique(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
