using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class ImageConfig
    {
        public static void RegisterImage(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .Property(e => e.ImageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Image>()
                .Property(e => e.ImageName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Image>()
                .Property(p => p.Image1)
                .HasColumnName("Image")
                .HasColumnType("image")
                .IsRequired();

            modelBuilder.Entity<Image>()
                .HasMany(e => e.EducationBlocks)
                .WithRequired(e => e.Image1)
                .HasForeignKey(e => e.Image)
                .WillCascadeOnDelete(false);
        }
    }
}
