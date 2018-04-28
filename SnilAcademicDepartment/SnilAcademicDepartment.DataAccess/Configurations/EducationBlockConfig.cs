using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class EducationBlockConfig
    {
        public static void RegisterEducation(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationBlock>()
                .HasKey(p => p.BlockId);

            modelBuilder.Entity<EducationBlock>()
                .Property(p => p.BlockId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<EducationBlock>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<EducationBlock>()
                .Property(p => p.Description)
                .HasColumnType("text");

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
