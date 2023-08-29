using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Modelos
{
    [Table("PATIENT")]
    public class PatientModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        [Column("NAME")]
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Nome do Paciente é obrigatório!")]
        [StringLength(65, MinimumLength = 4, ErrorMessage = "Nome do Paciente deve ser entre 4 e 65 letras.")]
        public string name{ get; set; }

        [Column("BIRTH_DATE")]
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [Required(ErrorMessage = "Data de Nascimento é obrigatório!")]
        [DateTimeRange(ErrorMessage = "Data de Nascimento fora do alcance permitido.")]
        public DateTime birthDate { get; set; }

        [Column("PHONE")]
        [DisplayName("Telefone")]
        public string phone { get; set; }

        [Column("RECOMMENDATION")]
        [DisplayName("Indicação")]
        public string recommendation { get; set; }

        [Column("OBSERVATION")]
        [DisplayName("Observação")]
        public string observation { get; set; }


    }
}
