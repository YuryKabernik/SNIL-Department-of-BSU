using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class SpecializationConfig
    {
        public static void RegisterSpecialization(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialisation>()
                .Property(p => p.SpecialisationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Specialisation>()
                .Property(p => p.SpecialisationName)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Specialisation>()
                .Property(p => p.Speciality)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Specialisation>()
                .HasMany(e => e.Lectures)
                .WithRequired(e => e.Specialisation)
                .HasForeignKey(e => e.SpesialisationId)
                .WillCascadeOnDelete(false);
        }
    }
}
