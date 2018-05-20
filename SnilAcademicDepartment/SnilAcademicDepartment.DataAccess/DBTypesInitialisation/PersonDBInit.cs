using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class PersonDBInit
    {
        public static void DBInit(
            SnilDBContext dBContext,
            string name,
            string secoundName,
            string fathers,
            Biography biogr,
            Image img,
            string acadTitle,
            string degree,
            Language lang,
            string status,
            string interests,
            List<Lecture> lectures,
            List<Seminar> seminars,
            List<Project> projects)
        {
            var obj = new Person()
            {
                PersonName = name,
                SecoundName = secoundName,
                FathersName = fathers,
                Biography1 = biogr,
                Image = img,
                AcademicTitle = acadTitle,
                Degree = degree,
                Language = lang,
                ProfessionStatus = status,
                PersonalInterests = interests,
                Lectures = lectures.Where(p => p.Language.LanguageCode == lang.LanguageCode).Take(3).ToArray(),
                Seminars = seminars.Where(p => p.Language.LanguageCode == lang.LanguageCode).Take(3).ToArray(),
                Projects = projects.Where(p => p.Language.LanguageCode == lang.LanguageCode).Take(3).ToArray()
            };
        }
    }
}
