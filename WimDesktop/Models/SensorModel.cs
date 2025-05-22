using System.ComponentModel.DataAnnotations.Schema;

namespace WimDesktop.Models
{
    [Table("SENSOR")]
    public class SensorModel
    {
        [Column("ID")]
        public int id { get; set; }

        [Column("NAME")]
        public string name { get; set; }

        [Column("NICKNAME")]
        public string nickname { get; set; }

        [Column("WIDTH")]
        public float width { get; set; }

        [Column("HEIGHT")]
        public float height { get; set; }
    }
}
