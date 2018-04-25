using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class PageTypeConfig
    {
        public static void RegisterPageType(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageType>()
                .HasMany(e => e.PreViews)
                .WithRequired(e => e.PageType1)
                .HasForeignKey(e => e.PageType)
                .WillCascadeOnDelete(false);
        }
    }
}
