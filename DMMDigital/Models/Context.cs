using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace DMMDigital.Models
{
    public class Context: DbContext
    {
        public Context() : base("Database")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>()
                .Property(p => p.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<ExamModel>()
                .Property(p => p.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<ExamImageModel>()
                .Property(p => p.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ConfigModel> config { get; set; }
        public DbSet<SensorModel> sensor { get; set; }
        public DbSet<RulerLengthModel> rulerLength { get; set; }
        public DbSet<ExamImageDrawingPointsModel> examImageDrawingPoints { get; set; }
        public DbSet<ExamImageDrawingModel> examImageDrawing { get; set; }
        public DbSet<ExamImageModel> examImage { get; set; }
        public DbSet<ExamModel> exam { get; set; }
        public DbSet<PatientModel> patient{ get; set; }
        public DbSet<TemplateFrameModel> templateFrame { get; set; }
        public DbSet<TemplateModel> template { get; set; }
    }
}
