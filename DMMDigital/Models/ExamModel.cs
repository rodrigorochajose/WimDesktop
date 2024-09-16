using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("EXAM")]
    public class ExamModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        [Column("PATIENT_ID")]
        public int patientId { get; set; }

        [Column("TEMPLATE_ID")]
        public int templateId { get; set; }

        [Column("SESSION_NAME")]
        [DisplayName("Nome da Sessão")]
        public string sessionName { get; set; }

        [Column("CREATED_AT")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        public virtual PatientModel patient { get; set; }
        public virtual TemplateModel template { get; set; }
        public virtual ICollection<ExamImageModel> examImages { get; set; }
    }

    public class ExamModelMap : ClassMap<ExamModel>
    {
        public ExamModelMap()
        {
            Map(m => m.id).Name("ID");
            Map(m => m.patientId).Name("PATIENT_ID");
            Map(m => m.templateId).Name("TEMPLATE_ID");
            Map(m => m.sessionName).Name("SESSION_NAME");
            Map(m => m.createdAt).Name("CREATED_AT");
        }
    }
}
