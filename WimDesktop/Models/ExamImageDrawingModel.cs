using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Windows.Documents;

namespace WimDesktop.Models
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

        [Column("DRAWING_COLOR")]
        public string drawingColor { get; set; }

        [Column("DRAWING_SIZE")]
        public int drawingSize { get; set; }

        [Column("DRAWING_TYPE")]
        public string drawingType { get; set; }

        [Column("DRAWING_TEXT")]
        public string drawingText { get; set; }

        [NotMapped]
        public List<Point> points { get; set; }

        [NotMapped]
        public List<float> lineLength { get; set; }
    }
}
