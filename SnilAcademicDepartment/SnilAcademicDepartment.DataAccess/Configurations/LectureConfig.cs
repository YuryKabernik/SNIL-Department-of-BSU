using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class LectureConfig
    {
        public static void RegisterLecture(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture>()
                .Property(p => p.LectureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Lecture>()
                .Property(p => p.LectureName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Lecture>()
                .Property(p => p.Description)
                .IsRequired();
        }
    }
}
