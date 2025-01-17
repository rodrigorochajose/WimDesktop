using CsvHelper.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("EXAM_IMAGE")]
    public class ExamImageModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        [Column("EXAM_ID")]
        public int examId { get; set; }

        [ForeignKey("examId")]
        public virtual ExamModel exam { get; set; }

        [Column("TEMPLATE_FRAME_ID")]
        public int templateFrameId { get; set; }

        [Column("FILE")]
        public string file { get; set; }

        [Column("NOTES")]
        public string notes { get; set; }

        [Column("CREATED_AT")]
        public DateTime createdAt { get; set; } = DateTime.Now;
    }

    public class ExamImageModelMap : ClassMap<ExamImageModel>
    {
        public ExamImageModelMap()
        {
            Map(m => m.id).Name("ID");
            Map(m => m.examId).Name("EXAM_ID");
            Map(m => m.templateFrameId).Name("TEMPLATE_FRAME_ID");
            Map(m => m.file).Name("FILE");
            Map(m => m.notes).Name("NOTES");
            Map(m => m.createdAt).Name("CREATED_AT");
        }
    }
}
