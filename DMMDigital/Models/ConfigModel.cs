using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("CONFIG")]
    public class ConfigModel
    {

        [Column("ID")]
        public int id { get; set; }

        [Column("EXAM_PATH")]
        public string examPath { get; set; }

        [Column("SENSOR_PATH")]
        public string sensorPath { get; set; }
    }
}
