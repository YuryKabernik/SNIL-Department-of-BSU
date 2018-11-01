using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
	/// <summary>
	/// Configuration for StudentTypes table.
	/// </summary>
	/// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{SnilAcademicDepartment.DataAccess.Models.StudentTypes}" />
	class StudentTypesConfig : EntityTypeConfiguration<StudentTypes>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StudentTypesConfig"/> class.
		/// </summary>
		public StudentTypesConfig()
		{
			this.HasKey(p => p.Id);
			this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			this.Property(p => p.TypeName)
				.IsRequired();

			this.Property(p => p.TypeUniqueId)
				.IsRequired();
		}
	}
}
