using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
	public class StuffDepartmentConfig : EntityTypeConfiguration<StuffDepartment>
	{
		public StuffDepartmentConfig()
		{
			this.ToTable("Stuff_Department");

			this.HasKey(p => p.Id);

			this.HasRequired(p => p.PersonId);

			this.Property(p => p.DataAssign)
				.HasColumnName("date_assign")
				.IsOptional();

			this.Property(p => p.DateRelease)
				.HasColumnName("date_release")
				.IsOptional();
		}
	}
}
