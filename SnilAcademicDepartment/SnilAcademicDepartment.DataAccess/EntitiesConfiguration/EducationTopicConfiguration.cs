using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    class EducationTopicConfiguration : EntityTypeConfiguration<EducationTopic>
    {
        public EducationTopicConfiguration()
        {
            this.Property(p => p.EducationTopicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.TopicName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
