using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraçãoDeTemplate.Modelos
{
    [Table("TEMPLATE")]
    public class Template
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("ID")]
        public int id { get; set; }

        [Column("NOME")]
        public string nome { get; set; }

        
    }
}
