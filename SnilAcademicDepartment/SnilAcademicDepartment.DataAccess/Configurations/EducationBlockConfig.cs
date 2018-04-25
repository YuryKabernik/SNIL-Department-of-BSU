using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class EducationBlockConfig
    {
        public static void RegisterEducation(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationBlock>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<EducationBlock>()
                .HasMany(e => e.EducationTopics)
                .WithRequired(e => e.EducationBlock)
                .HasForeignKey(e => e.EducationBlockType)
                .WillCascadeOnDelete(false);

        }
    }
}
