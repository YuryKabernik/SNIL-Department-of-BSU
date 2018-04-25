using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class ImageConfig
    {
        public static void RegisterImage(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasMany(e => e.EducationBlocks)
                .WithRequired(e => e.Image1)
                .HasForeignKey(e => e.Image)
                .WillCascadeOnDelete(false);
        }
    }
}
