using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Document = document,
                EventDate = DateTime.UtcNow
            };

            seminars.Add(seminar);

            dBContext.Seminars.Add(seminar);
            dBContext.SaveChanges();
        }
    }
}
