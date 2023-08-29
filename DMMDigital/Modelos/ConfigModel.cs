using System.ComponentModel.DataAnnotations.Schema;

namespace DMMDigital.Modelos
{
    [Table("CONFIGURACAO")]
    public class ConfigModel
    {

        [Column("ID")]
        public int id { get; set; }

        [Column("CAMINHO_RADIOGRAFIA")]
        public string caminho_radiografia { get; set; }
    }
}
