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

        [Column("FRAME_ID")]
        public int frameId { get; set; }

        [Column("FILE")]
        public string file { get; set; }

        [Column("NOTES")]
        public string notes { get; set; }

        [Column("CREATED_AT")]
        public DateTime createdAt { get; set; }
    }
}
