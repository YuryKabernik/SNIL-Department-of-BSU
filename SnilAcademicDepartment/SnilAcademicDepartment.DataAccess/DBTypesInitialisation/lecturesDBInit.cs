using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnilAcademicDepartment.DataAccess.Models;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class LecturesDBInit
    {
        private static string _description = @"Description is the pattern of narrative development that presents a word picture of a thing, a person, a situation,
            or a series of events. Description is one of four rhetorical modes(also known as modes of discourse),
            along with exposition, argumentation, and narration.Each of the rhetorical modes is present in a variety of forms and each has its own purpose and conventions.
            The act of description may be related to that of definition.Description is also the fiction-writing mode for transmitting a mental image of the particulars of a story";

        public static void DBInit(SnilDBContext dBContext, string name, Language lang, List<Lecture> lectures, Document document)
        {
            var lecture = new Lecture
            {
                LectureName = lang.LanguageName + name,
                Description = lang.LanguageName + _description,
				LectureType = "none",
                Language = lang,
                Document = CopyDocument(document),
                Specialisation = new Specialisation { SpecialisationName = "SPName" + lang.LanguageName, Speciality = "Specil", Language = lang}
            };

            lectures.Add(lecture);

            dBContext.Lectures.Add(lecture);
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
