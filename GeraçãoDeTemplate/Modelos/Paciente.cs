using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraçãoDeTemplate.Modelos
{
    [Table("PACIENTE")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        [Column("NOME")]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Column("DATA_NASCIMENTO")]
        [DisplayName("Data de Nascimento")]
        public DateTime data_nascimento { get; set; }

        [Column("TELEFONE")]
        [DisplayName("Telefone")]
        public string telefone { get; set; }

        [Column("INDICACAO")]
        [DisplayName("Indicação")]
        public string indicacao { get; set; }

        [Column("OBSERVACAO")]
        [DisplayName("Observação")]
        public string observacao { get; set; }


    }
}
