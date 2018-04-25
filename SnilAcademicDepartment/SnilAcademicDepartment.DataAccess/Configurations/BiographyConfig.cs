using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class BiographyConfig
    {
        public static void RegisterBiography(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biography>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Biography1)
                .HasForeignKey(e => e.Biography)
                .WillCascadeOnDelete(false);
        }
    }
}
