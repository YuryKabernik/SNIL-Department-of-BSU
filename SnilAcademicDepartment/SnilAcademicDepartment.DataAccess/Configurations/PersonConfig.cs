using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class PersonConfig
    {
        public static void RegisterPerson(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(p => p.PersonId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.PersonName)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.SecoundName)
                .HasMaxLength(25)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.FathersName)
                .HasMaxLength(25)
                .IsRequired();
            modelBuilder.Entity<Person>()
                .Property(p => p.ProfessionStatus)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.Degree)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.AcademicTitle)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(p => p.PersonalInterests)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.HallOfFames)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Projects)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("ProjectPerson").MapLeftKey("PersonId").MapRightKey("ProjectId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Seminars)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("SeminarPersons").MapLeftKey("PersonId").MapRightKey("SeminarId"));

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Lectures)
                .WithMany(e => e.People)
                .Map(m => m.ToTable("LecturePerson").MapLeftKey("PersonId").MapRightKey("LectureId"));
        }
    }
}
