using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
	public class ProfessionStatusConfig : EntityTypeConfiguration<ProfessionStatus>
	{
		public void RegisterProfessionStatus()
		{
			this.Property(s => s.Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
				.IsRequired();
		}
	}
}
