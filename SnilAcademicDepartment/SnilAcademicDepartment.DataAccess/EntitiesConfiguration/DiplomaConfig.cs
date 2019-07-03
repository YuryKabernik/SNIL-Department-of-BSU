using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models.Education;

namespace SnilAcademicDepartment.DataAccess.EntitiesConfiguration
{
	public class DiplomaConfig : EntityTypeConfiguration<Diploma>
	{
		public DiplomaConfig()
		{
			this.Property(p => p.DiplomaId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.HasRequired(p => p.Localization);

			this.Property(p => p.ProtectionDate)
				.IsRequired();

            this.Property(p => p.Name)
                .IsOptional();

            this.Property(p => p.Description)
				.IsOptional();

			this.Property(p => p.Type)
				.IsOptional();

			this.HasOptional(p => p.Teachers)
				.WithMany();
		}
	}
}
