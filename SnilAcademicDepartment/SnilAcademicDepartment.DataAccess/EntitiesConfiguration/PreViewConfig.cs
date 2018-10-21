using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class PreViewConfig : EntityTypeConfiguration<PreView>
    {
        public PreViewConfig()
        {
            this.Property(e => e.PreViewId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Header)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(e => e.ShortDescription)
                .HasColumnType("text")
                .IsRequired()
                .IsUnicode(false);

            this.Property(p => p.Image)
                .HasColumnType("image")
                .IsRequired();
        }
    }
}
