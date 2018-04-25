using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class PreViewConfig
    {
        public static void RegisterPreView(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreView>()
                .Property(e => e.ShortDescription)
                .IsUnicode(false);
        }
    }
}
