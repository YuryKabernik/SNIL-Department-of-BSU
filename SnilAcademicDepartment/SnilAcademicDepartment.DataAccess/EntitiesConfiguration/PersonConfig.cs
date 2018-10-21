using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
	public class PersonConfig : EntityTypeConfiguration<Person>
	{
		public void RegisterPerson()
		{
			this.Property(p => p.PersonId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
				.IsRequired();

			this.Property(p => p.PersonName)
				.HasMaxLength(20)
				.IsRequired();

			this.Property(p => p.SecoundName)
				.HasMaxLength(25)
				.IsRequired();

			this.Property(p => p.FathersName)
				.HasMaxLength(25)
				.IsRequired();

			//this.Property(p => p.ProfessionStatus)
			//	.HasMaxLength(50)
			//	.IsRequired();

			//this.Property(p => p.Degree)
			//	.HasMaxLength(50)
			//	.IsRequired();

			//this.Property(p => p.AcademicTitle)
			//	.HasMaxLength(50)
			//	.IsRequired();

			this.Property(p => p.PersonalInterests)
				.HasMaxLength(50)
				.IsRequired();

			this.Property(p => p.EmailAddress)
				.HasMaxLength(50)
				.IsOptional();

			this.Property(p => p.PhoneNumber)
				.HasMaxLength(50)
				.IsOptional();

			this.HasMany(e => e.HallOfFames)
				.WithRequired(e => e.Person)
				.WillCascadeOnDelete(false);

			this.HasMany(e => e.Projects)
				.WithMany(e => e.People)
				.Map(m => m.ToTable("ProjectPerson").MapLeftKey("PersonId").MapRightKey("ProjectId"));

			this.HasMany(e => e.Seminars)
				.WithMany(e => e.People)
				.Map(m => m.ToTable("SeminarPerson").MapLeftKey("PersonId").MapRightKey("SeminarId"));

			this.HasMany(e => e.Lectures)
				.WithMany(e => e.People)
				.Map(m => m.ToTable("LecturePerson").MapLeftKey("PersonId").MapRightKey("LectureId"));
		}
	}
}
