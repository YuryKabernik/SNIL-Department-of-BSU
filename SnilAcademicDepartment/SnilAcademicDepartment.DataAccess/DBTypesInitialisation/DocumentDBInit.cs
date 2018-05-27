using System;
using System.IO;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class DocumentDBInit
    {
        public static void DBInit(SnilDBContext db, byte[] content, string path, out Document document)
        {
            document = new Document()
            {
                DocumentName = "Document!",
                FileContent = content,
                CreatedOn = DateTime.UtcNow.AddDays(-1),
                ModifiedOn = DateTime.UtcNow,
                FileType = GetDocumentExtenction(path)
            };

            db.Documents.Add(document);
            db.SaveChanges();
        }

        private static string GetDocumentExtenction(string path)
        {
            var info = new FileInfo(path);
            return info.Extension;
        }
    }
}
