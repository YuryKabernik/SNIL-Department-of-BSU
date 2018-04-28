using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class PageTypeConfig
    {
        public static void RegisterPageType(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageType>()
                .Property(p => p.PageTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PageType>()
                .Property(p => p.PageTypeName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<PageType>()
                .HasMany(e => e.PreViews)
                .WithRequired(e => e.PageTypeName)
                .HasForeignKey(e => e.PageType)
                .WillCascadeOnDelete(false);
        }
    }
}
