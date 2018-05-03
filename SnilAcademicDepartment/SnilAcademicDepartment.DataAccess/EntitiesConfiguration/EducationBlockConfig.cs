using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class EducationBlockConfig : EntityTypeConfiguration<EducationBlock>
    {
        public EducationBlockConfig()
        {
            this.HasKey(p => p.BlockId);

            this.Property(p => p.BlockId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Name)
                .HasMaxLength(50);

            this.Property(p => p.Description)
                .HasColumnType("text");

            this.Property(e => e.Description)
                .IsUnicode(false);

            this.HasMany(e => e.EducationTopics)
                .WithRequired(e => e.EducationBlock)
                .HasForeignKey(e => e.EducationBlockType)
                .WillCascadeOnDelete(false);

        }
    }
}
