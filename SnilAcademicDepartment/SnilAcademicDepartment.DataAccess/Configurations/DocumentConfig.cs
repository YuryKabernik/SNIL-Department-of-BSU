using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class DocumentConfig
    {
        public static void RegisterDocument(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .Property(e => e.DocumentId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Document>()
                .Property(e => e.DocumentName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Document>()
                .Property(e => e.FileContent)
                .HasMaxLength(8000)
                .IsRequired();

            modelBuilder.Entity<Document>()
                .HasMany(e => e.Seminars)
                .WithOptional(e => e.Document)
                .HasForeignKey(e => e.DocFile);

        }
    }
}
