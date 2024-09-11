using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("EXAM_IMAGE_DRAWING_POINTS")]
    public class ExamImageDrawingPointsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        [Column("EXAM_IMAGE_DRAWING_ID")]
        public int examImageDrawingId { get; set; }

        [Column("POINT_X")]
        public int pointX { get; set; }

        [Column("POINT_Y")]
        public int pointY { get; set; }
    }
}
