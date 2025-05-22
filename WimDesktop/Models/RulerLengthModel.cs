using System.ComponentModel.DataAnnotations.Schema;

namespace WimDesktop.Models
{
    [Table("RULER_LENGTH")]
    public class RulerLengthModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("EXAM_IMAGE_DRAWING_ID")]
        public int examImageDrawingId { get; set; }

        [Column("LINE_LENGTH")]
        public float lineLength { get; set; }
    }
}
