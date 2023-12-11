using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Modelos
{
    [Table("EXAM_IMAGE_DRAWING")]
    public class ExamImageDrawingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        [Column("EXAM_ID")]
        public int examId { get; set; }

        [Column("EXAM_IMAGE_ID")]
        public int examImageId { get; set; }

        [Column("FILE")]
        public string file { get; set; }
    }
}
