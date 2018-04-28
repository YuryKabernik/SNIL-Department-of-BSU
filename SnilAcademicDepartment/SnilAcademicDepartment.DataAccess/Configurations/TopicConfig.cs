using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class TopicConfig
    {
        public static void RegisterTopic(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .Property(p => p.TopicId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Topic>()
                .Property(p => p.TopicName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Seminars)
                .WithOptional(e => e.Topic1)
                .HasForeignKey(e => e.Topic);
        }
    }
}
