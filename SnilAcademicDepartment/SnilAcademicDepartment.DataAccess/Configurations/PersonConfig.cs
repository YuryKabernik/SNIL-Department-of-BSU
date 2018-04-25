using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class PersonConfig
    {
        public static void RegisterPerson(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(e => e.HallOfFames)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonLectures)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LectureId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("ProjectPerson").MapLeftKey("PersonId").MapRightKey("ProjectId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Seminars)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("SeminarPersons").MapLeftKey("Person").MapRightKey("Seminar"));
        }
    }
}
