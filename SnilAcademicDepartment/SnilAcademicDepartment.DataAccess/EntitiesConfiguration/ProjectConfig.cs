using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    class ProjectConfig : EntityTypeConfiguration<Project>
    {
        public ProjectConfig()
        {
            this.Property(p => p.ProjectId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.CommonID)
                .IsRequired();

            this.Property(p => p.ProjectName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(p => p.Description)
                .IsRequired();

            this.Property(p => p.ShortDescription)
                .HasMaxLength(400)
                .IsRequired();

            this.Property(p => p.ProjectStatus)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
