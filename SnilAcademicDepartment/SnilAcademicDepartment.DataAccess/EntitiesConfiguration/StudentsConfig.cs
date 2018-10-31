using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
	public class StudentsConfig : EntityTypeConfiguration<Students>
	{
		public StudentsConfig()
		{
			this.ToTable("Students");

			this.HasKey(p => p.Id);

			this.Property(p => p.FirstName)
				.HasMaxLength(50)
				.IsRequired();

			this.Property(p => p.SecoundName)
				.HasMaxLength(50)
				.IsRequired();

			this.Property(p => p.LastName)
				.HasMaxLength(50)
				.IsRequired();

			this.Property(p => p.StudentsGroup)
				.HasMaxLength(50)
				.IsRequired();

			this.Property(p => p.GraduationYear)
				.IsOptional();
		}
	}
}
