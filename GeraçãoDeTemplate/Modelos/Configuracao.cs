using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraçãoDeTemplate.Modelos
{
    [Table("CONFIGURACAO")]
    internal class Configuracao
    {

        [Column("ID")]
        public int id { get; set; }

        [Column("CAMINHO_RADIOGRAFIA")]
        public string caminho_radiografia { get; set; }
    }
}
