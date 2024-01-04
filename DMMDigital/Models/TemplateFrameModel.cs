using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("TEMPLATE_FRAME")]
    public class TemplateFrameModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id {  get; set; }

        [Column("TEMPLATE_ID")]
        public int templateId { get; set; }
        public virtual TemplateModel template { get; set; }

        [Column("ORDER")]
        public int order { get; set; }

        [Column("LOCATION_X")]
        public int locationX { get; set; }

        [Column("LOCATION_Y")]
        public int locationY { get; set; }

        [Column("ORIENTATION")]
        public string orientation { get; set; }


    }
}
