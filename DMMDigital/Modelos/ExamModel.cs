using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Modelos
{
    [Table("EXAM")]
    public class ExamModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        public virtual PatientModel patient { get; set; }

        [Column("PATIENT_ID")]
        public int patientId { get; set; }


        [Column("TEMPLATE_ID")]
        public int templateId { get; set; }

        public virtual TemplateModel template { get; set; }

        [Column("SESSION_NAME")]
        [DisplayName("Nome da Sessão")]
        public string sessionName { get; set; }

        [Column("CREATED_AT")]
        public DateTime createdAt { get; set; }

    }
}
