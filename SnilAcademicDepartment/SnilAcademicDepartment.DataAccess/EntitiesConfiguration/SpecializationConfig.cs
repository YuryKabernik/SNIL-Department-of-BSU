using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class SpecializationConfig : EntityTypeConfiguration<Specialisation>
    {
        public SpecializationConfig()
        {
            this.Property(p => p.SpecialisationId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.SpecialisationName)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(p => p.Speciality)
                .HasMaxLength(100)
                .IsRequired();

            this.HasMany(e => e.Lectures)
                .WithRequired(e => e.Specialisation)
                .HasForeignKey(e => e.SpesialisationId)
                .WillCascadeOnDelete(false);
        }
    }
}
