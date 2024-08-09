using DMMDigital.Properties;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Models
{
    [Table("TEMPLATE")]
    public class TemplateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("ID")]
        public int id { get; set; }

        [Column("NAME")]
        public string name { get; set; }
    }
}
