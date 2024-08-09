using DMMDigital.Properties;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
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
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "messagePatientRequiredName")]
        [StringLength(65, MinimumLength = 4, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "messageRequiredPatientName")]
        public string name{ get; set; }

        [Column("BIRTH_DATE")]
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "messagePatientRequiredBirthDate")]
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
