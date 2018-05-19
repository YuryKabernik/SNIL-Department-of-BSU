using System;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class DocumentDBInit
    {
        public static void DBInit(SnilDBContext db, byte[] content, out Document document)
        {
            document = new Document()
            {
                DocumentName = "Document!",
                FileContent = content,
                CreatedOn = DateTime.UtcNow.AddDays(-1),
                ModifiedOn = DateTime.UtcNow
            };

            db.Documents.Add(document);
            db.SaveChanges();
        }
    }
}
