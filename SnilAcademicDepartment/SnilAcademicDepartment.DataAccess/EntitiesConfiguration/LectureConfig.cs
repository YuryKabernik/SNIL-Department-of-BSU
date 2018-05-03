using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class LectureConfig : EntityTypeConfiguration<Lecture>
    {
        public LectureConfig()
        {
            this.Property(p => p.LectureId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.LectureName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(p => p.Description)
                .IsRequired();
        }
    }
}
