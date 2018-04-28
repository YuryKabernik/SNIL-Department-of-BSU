using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class TopicConfig : EntityTypeConfiguration<Topic>
    {
        public TopicConfig()
        {
            this.Property(p => p.TopicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.TopicName)
                .IsRequired()
                .HasMaxLength(100);

            this.HasMany(e => e.Seminars)
                .WithOptional(e => e.Topic1)
                .HasForeignKey(e => e.Topic);
        }
    }
}
