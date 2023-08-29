using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Modelos
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
        public string frameId { get; set; }
    }
}
