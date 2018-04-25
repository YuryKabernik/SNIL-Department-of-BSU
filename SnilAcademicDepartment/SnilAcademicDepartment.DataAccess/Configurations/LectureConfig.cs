using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class LectureConfig
    {
        public static void RegisterLecture(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture>()
                .HasMany(e => e.PersonLectures)
                .WithRequired(e => e.Lecture)
                .WillCascadeOnDelete(false);
        }
    }
}
