using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
	public class StuffStudentsConfig : EntityTypeConfiguration<StuffStudents>
	{
		public StuffStudentsConfig()
		{
			this.ToTable("Stuff_Students");

			this.HasKey(p => p.Id);

			this.HasRequired(p => p.Student);

			this.Property(p => p.DateEntrance)
				.HasColumnName("date_entrance")
				.IsOptional();

			this.Property(p => p.DateDeparture)
				.HasColumnName("date_departure")
				.IsOptional();
		}
	}
}
