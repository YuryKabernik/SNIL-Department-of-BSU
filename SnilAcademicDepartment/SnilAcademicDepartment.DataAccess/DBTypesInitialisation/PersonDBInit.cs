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
            Lecture[] lectures,
            Seminar[] seminars,
            Project[] projects)
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
                Lectures = lectures,
                Seminars = seminars,
                Projects = projects
            };
        }
    }
}
