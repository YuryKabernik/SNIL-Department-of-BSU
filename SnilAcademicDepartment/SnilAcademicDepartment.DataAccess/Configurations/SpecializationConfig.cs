using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class SpecializationConfig
    {
        public static void RegisterSpecialization(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialisation>()
                .HasMany(e => e.Lectures)
                .WithRequired(e => e.Specialisation)
                .HasForeignKey(e => e.SpesialisationId)
                .WillCascadeOnDelete(false);
        }
    }
}
