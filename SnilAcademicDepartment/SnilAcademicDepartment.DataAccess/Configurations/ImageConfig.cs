using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class ImageConfig : EntityTypeConfiguration<Image>
    {
        public ImageConfig()
        {
            this.Property(e => e.ImageId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.ImageName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(p => p.Image1)
                .HasColumnName("Image")
                .HasColumnType("image")
                .IsRequired();

            this.HasMany(e => e.EducationBlocks)
                .WithRequired(e => e.Image1)
                .HasForeignKey(e => e.Image)
                .WillCascadeOnDelete(false);
        }
    }
}
