using System.Data.Entity;

namespace DMMDigital.Modelos
{
    public class Contexto<T> : DbContext where T : class
    {
        public Contexto() : base("Database")
        { 
        }

        public DbSet<T> tabela { get; set; }
    }
}
