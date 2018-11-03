using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
	public class StuffPersonalConfig : EntityTypeConfiguration<StuffPersonal>
	{
		public StuffPersonalConfig()
		{
			this.HasKey(k => k.Id);

			this.ToTable("Stuff_personal")
				.Property(p => p.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(p => p.ReleaseDate)
				.IsOptional();

			this.Property(p => p.AssignmentDate)
				.IsOptional();

			this.HasRequired(p => p.PersonId)
				.WithMany(p => p.StuffPeople)
				.WillCascadeOnDelete(false);

		}
	}
}
