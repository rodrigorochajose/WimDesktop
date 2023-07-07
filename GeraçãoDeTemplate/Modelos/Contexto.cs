using System.Data.Entity;

namespace GeraçãoDeTemplate.Modelos
{
    internal class Contexto<T> : DbContext where T : class
    {
        public Contexto() : base("Database")
        { 
        }

        public DbSet<T> tabela { get; set; }
    }
}
