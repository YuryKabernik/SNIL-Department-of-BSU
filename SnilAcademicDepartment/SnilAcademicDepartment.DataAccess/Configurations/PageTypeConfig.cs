using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class PageTypeConfig : EntityTypeConfiguration<PageType>
    {
        public PageTypeConfig()
        {
            this.Property(p => p.PageTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.PageTypeName)
                .HasMaxLength(50)
                .IsRequired();

            this.HasMany(e => e.PreViews)
                .WithRequired(e => e.PageTypeName)
                .HasForeignKey(e => e.PageType)
                .WillCascadeOnDelete(false);
        }
    }
}
