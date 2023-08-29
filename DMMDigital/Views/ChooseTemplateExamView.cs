using DMMDigital.Modelos;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Forms
{
    public partial class ChooseTemplateExamView : Form, IChooseTemplateExamView
    {
        //Contexto<Template> contextoTemplate = new Contexto<Template>();
        //PatientModel pacienteExame = null;
        //List<TemplateLayout> listaTemplateLayout = null;
        //public ChooseTemplateExamView(int idPaciente)
        //{
        //    InitializeComponent();

        //    Contexto<PatientModel> contextoPaciente = new Contexto<PatientModel>();

        //    pacienteExame = contextoPaciente.tabela.Find(idPaciente);
        //    textBoxName.Text = pacienteExame.name;
        //    textBoxBirthDate.Text = pacienteExame.birthDate.ToString();
        //    textBoxPhone.Text = pacienteExame.phone;
        //    textBoxRecommendation.Text = pacienteExame.recommendation;
        //    textBoxObservation.Text = pacienteExame.observation;

        //    comboBoxTemplate.DataSource = contextoTemplate.tabela.ToList();
        //    comboBoxTemplate.DisplayMember = "nome";
        //    comboBoxTemplate.ValueMember = "id";

        //}

        //private void novoTemplateClique(object sender, EventArgs e)
        //{
        //    GeracaoTemplate novoForm = new GeracaoTemplate();
        //    novoForm.ShowDialog();

        //    comboBoxTemplate.DataSource = contextoTemplate.tabela.ToList();
        //}

        //private void selecionaTemplate(object sender, EventArgs e)
        //{
        //    limparTemplate();

        //    Contexto<TemplateLayout> contextoTemplateLayout = new Contexto<TemplateLayout>();

        //    int templateId = int.Parse(comboBoxTemplate.SelectedValue.ToString());
        //    int altura = 0, largura = 0;

        //    listaTemplateLayout = contextoTemplateLayout.tabela.Where(ctl => ctl.templateID == templateId).ToList();

        //    foreach (TemplateLayout tl in listaTemplateLayout)
        //    {
        //        if (tl.orientacao.Contains("Vertical"))
        //        {
        //            altura = 35;
        //            largura = 25;
        //        }
        //        else
        //        {
        //            altura = 25;
        //            largura = 35;
        //        }

        //        PictureBox novoFilme = new PictureBox
        //        {
        //            Width = largura,
        //            Height = altura,
        //            BackColor = Color.Black,
        //        };


        //        Bitmap image = new Bitmap(novoFilme.Width, novoFilme.Height);
        //        Graphics graphics = Graphics.FromImage(image);
        //        Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
        //        graphics.DrawString(tl.ordem.ToString(), font, Brushes.White, new Point(0, 0));
        //        novoFilme.Image = image;
        //        novoFilme.Location = new Point(tl.posicaoX / 2, tl.posicaoY / 2);

        //        panel3.Controls.Add(novoFilme);
        //    }
        //}

        //private void limparTemplate()
        //{
        //    List<PictureBox> painel = this.panel3.Controls.Cast<PictureBox>().ToList();

        //    if (painel != null)
        //    {
        //        foreach (PictureBox pb in painel)
        //        {
        //            this.panel3.Controls.Remove(pb);
        //        }
        //    }
        //}

        //private void botaoIniciarRadiografiaClique(object sender, EventArgs e)
        //{
        //    Exame novoForm = new Exame(pacienteExame, listaTemplateLayout, comboBoxTemplate.Text, textBoxSessionName.Text);
        //    novoForm.Show();
        //    Close();
        //}

        public ChooseTemplateExamView()
        {
            InitializeComponent();
            associateEvents();
        }

        private void associateEvents()
        {
            
        }

        public int patientId { get; set; }

        public string patientName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        public DateTime patientBirthDate
        {
            get { return DateTime.Parse(textBoxBirthDate.Text); }
            set { textBoxBirthDate.Text = value.ToString(); }
        }

        public string patientPhone
        {
            get { return textBoxPhone.Text; }
            set { textBoxPhone.Text = value; }
        }

        public string patientRecommendation
        {
            get { return textBoxRecommendation.Text; }
            set { textBoxRecommendation.Text = value; }
        }

        public string patientObservation
        {
            get { return textBoxObservation.Text; }
            set { textBoxObservation.Text = value; }
        }

        public string sessionName 
        {
            get { return textBoxSessionName.Text; }
            set { textBoxSessionName.Text = value; }
        }
        public int templateId
        { 
            get { return int.Parse(comboBoxTemplate.SelectedValue.ToString()); }
            set { this.comboBoxTemplate.SelectedValue = value; }
        }


        public event EventHandler eventAddNewTemplate;
        public event EventHandler eventInitializeExam;

        public void setTemplateList(List<TemplateModel> templateList)
        {
            comboBoxTemplate.DataSource = templateList;
            comboBoxTemplate.DisplayMember = "name";
            comboBoxTemplate.ValueMember = "id";
        }

    }
}
