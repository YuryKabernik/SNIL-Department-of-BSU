using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class PreViewConfig
    {
        public static void RegisterPreView(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreView>()
                .Property(e => e.PreViewId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PreView>()
                .Property(e => e.Header)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<PreView>()
                .Property(e => e.ShortDescription)
                .HasColumnType("text")
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<PreView>()
                .Property(p => p.Image)
                .HasColumnType("image")
                .IsRequired();
        }
    }
}
