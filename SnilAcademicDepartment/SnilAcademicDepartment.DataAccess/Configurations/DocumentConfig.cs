using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess.Configurations
{
    public static class DocumentConfig
    {
        public static void RegisterDocument(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .Property(e => e.DocumentName)
                .IsFixedLength();

            modelBuilder.Entity<Document>()
                .Property(e => e.FileContent)
                .IsFixedLength();

            modelBuilder.Entity<Document>()
                .HasMany(e => e.Seminars)
                .WithOptional(e => e.Document)
                .HasForeignKey(e => e.DocFile);

        }
    }
}
