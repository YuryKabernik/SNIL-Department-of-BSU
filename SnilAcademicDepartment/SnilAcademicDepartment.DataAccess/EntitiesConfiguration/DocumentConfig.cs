using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public class DocumentConfig : EntityTypeConfiguration<Document>
    {
        public DocumentConfig()
        {
            this.Property(e => e.DocumentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.DocumentName)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(e => e.FileContent)
                .IsRequired();

            this.HasMany(e => e.Seminars)
                .WithOptional(e => e.Document)
                .HasForeignKey(e => e.DoctId);

        }
    }
}
