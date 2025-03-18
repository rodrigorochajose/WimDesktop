using CsvHelper.Configuration;
using DMMDigital.Properties;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace DMMDigital.Models
{
    [Table("CLINIC")]
    public class ClinicModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int id { get; set; }

        [Column("NAME")]
        [DisplayName("Nome")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "messageClinicRequiredName")]
        [StringLength(130)]
        public string name { get; set; }

        [Column("EMAIL")]
        [DisplayName("Email")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "messageClinicRequiredEmail")]
        [StringLength(130)]
        public string email { get; set; }

        [Column("PASSWORD")]
        [DisplayName("Senha")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "messageClinicRequiredPassword")]
        public string password { get; set; }

        [Column("CREATED_AT")]
        public DateTime createdAt { get; set; } = DateTime.Now;

        [Column("KEEP_CONNECTED")]
        public int keepConnected { get; set; } = 0;
    }

    public class ClinicModelMap : ClassMap<ClinicModel>
    {
        public ClinicModelMap()
        {
            Map(m => m.id).Name("ID");
            Map(m => m.name).Name("NAME");
            Map(m => m.email).Name("EMAIL");
            Map(m => m.password).Name("PASSWORD");
            Map(m => m.createdAt).Name("CREATED_AT");
        }
    }
}
