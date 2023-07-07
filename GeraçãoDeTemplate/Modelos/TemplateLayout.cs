using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraçãoDeTemplate.Modelos
{
    [Table("TEMPLATE_LAYOUT")]
    public class TemplateLayout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id {  get; set; }

        [Column("TEMPLATEID")]
        public int templateID { get; set; }
        public virtual Template template { get; set; }

        [Column("ORDEM")]
        public int ordem { get; set; }

        [Column("POSICAOX")]
        public int posicaoX { get; set; }

        [Column("POSICAOY")]
        public int posicaoY { get; set; }

        [Column("ORIENTACAO")]
        public string orientacao { get; set; }


    }
}
