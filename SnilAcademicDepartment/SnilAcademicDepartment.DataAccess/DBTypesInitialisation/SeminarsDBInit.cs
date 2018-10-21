using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class SeminarsDBInit
    {
        public static void DBInit(SnilDBContext dBContext, string title, Language language, Document document, List<Seminar> seminars)
        {
            var seminar = new Seminar
            {
                Title = title,
                Topic1 = new Topic { TopicName = title + "Global Topic" },
                Language = language,
                Document = CopyDocument(document),
                EventDate = DateTime.UtcNow
            };

            seminars.Add(seminar);

            dBContext.Seminars.Add(seminar);
            dBContext.SaveChanges();
        }

        private static Document CopyDocument(Document document)
        {
            return new Document
            {
                DocumentName = document.DocumentName,
                FileContent = document.FileContent,
                CreatedOn = document.CreatedOn.AddDays(-3),
                IsDeleted = document.IsDeleted,
                ModifiedOn = document.ModifiedOn,
                FileTypeExtenction = document.FileTypeExtenction
            };
        }
    }
}
