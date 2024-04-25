using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("CONFIG")]
    public class ConfigModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("SENSOR_PATH")]
        public string sensorPath { get; set; }

        [Column("EXAM_PATH")]
        public string examPath { get; set; }

        [Column("DRAWING_COLOR")]
        public string drawingColor { get; set; }

        [Column("DRAWING_SIZE")]
        public int drawingSize { get; set; }

        [Column("TEXT_COLOR")]
        public string textColor { get; set; }

        [Column("TEXT_SIZE")]
        public int textSize { get; set; }

        [Column("RULER_COLOR")]
        public string rulerColor { get; set; }
    }
}
