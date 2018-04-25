using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class TopicConfig
    {
        public static void RegisterTopic(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Seminars)
                .WithOptional(e => e.Topic1)
                .HasForeignKey(e => e.Topic);
        }
    }
}
