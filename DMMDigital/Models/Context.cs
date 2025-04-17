using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;

namespace DMMDigital.Models
{
    public class Context : DbContext
    {
        public Context() : base("Database")
        {
        }

        public DbSet<SettingsModel> settings { get; set; }
        public DbSet<ClinicModel> clinic { get; set; }
        public DbSet<SensorModel> sensor { get; set; }
        public DbSet<RulerLengthModel> rulerLength { get; set; }
        public DbSet<ExamImageDrawingPointsModel> examImageDrawingPoints { get; set; }
        public DbSet<ExamImageDrawingModel> examImageDrawing { get; set; }
        public DbSet<ExamImageModel> examImage { get; set; }
        public DbSet<ExamModel> exam { get; set; }
        public DbSet<PatientModel> patient { get; set; }
        public DbSet<TemplateFrameModel> templateFrame { get; set; }
        public DbSet<TemplateModel> template { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HistoryRow>()
                .HasKey(h => new { h.MigrationId, h.ContextKey });

            modelBuilder.Entity<HistoryRow>()
                .Property(h => h.MigrationId)
                .HasMaxLength(100);

            modelBuilder.Entity<HistoryRow>()
                .Property(h => h.ContextKey)
                .HasMaxLength(100); 

            modelBuilder.Entity<HistoryRow>()
                .Property(h => h.Model)
                .HasColumnType("BLOB");
        }
    }

    public class CustomHistoryContext : HistoryContext
    {
        public CustomHistoryContext(DbConnection existingConnection, string defaultSchema)
            : base(existingConnection, defaultSchema)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HistoryRow>()
                .HasKey(h => new { h.MigrationId, h.ContextKey }); 
            modelBuilder.Entity<HistoryRow>()
                .Property(h => h.MigrationId)
                .HasMaxLength(100);

            modelBuilder.Entity<HistoryRow>()
                .Property(h => h.ContextKey)
                .HasMaxLength(100);

            modelBuilder.Entity<HistoryRow>()
                .Property(h => h.Model)
                .HasColumnType("BLOB");
        }
    }

    public class ModifiedDbConfiguration : DbConfiguration
    {
        public ModifiedDbConfiguration()
        {
            SetHistoryContext("FirebirdSql.Data.FirebirdClient", (conn, schema) => new CustomHistoryContext(conn, schema));
        }
    }
}
