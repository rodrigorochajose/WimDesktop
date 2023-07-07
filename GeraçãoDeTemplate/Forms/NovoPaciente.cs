using GeraçãoDeTemplate.Modelos;
using System;
using System.IO;
using System.Windows.Forms;

namespace GeraçãoDeTemplate.Forms
{

    public partial class NovoPaciente : Form
    {
        public NovoPaciente()
        {
            InitializeComponent();
        }

        private void botaoNovoPacienteClique(object sender, EventArgs e)
        {
            var contexto = new Contexto<Paciente>();
            Paciente novoPaciente = new Paciente()
            {
                nome = txtNome.Text,
                data_nascimento = dataNascimento.Value,
                telefone = txtTelefone.Text,
                indicacao = txtIndicacao.Text,
                observacao = txtObservacao.Text,
            };

            try
            {
                contexto.tabela.Add(novoPaciente);
                contexto.SaveChanges();

                Directory.CreateDirectory(@"C:\Users\USER\.novowimdesktop\img\Paciente-" + novoPaciente.id);

                MessageBox.Show("Paciente cadastrado.");
                Pacientes novoFormFilho = new Pacientes();
                novoFormFilho.MdiParent = this.MdiParent;
                novoFormFilho.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro");
            }

        }

        private void botaoCancelarClique(object sender, EventArgs e)
        {
            var formPrincipal = new Pacientes();
            this.Close();
        }

    }
}
