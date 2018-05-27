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
            var person = new Person()
            {
                PersonName = name,
                SecoundName = secoundName,
                FathersName = fathers,
                Biography1 = CopyBiography(name, biogr),
                Image = CopyImage(img),
                AcademicTitle = acadTitle,
                Degree = degree,
                Language = lang,
                ProfessionStatus = status,
                PersonalInterests = interests,
                Lectures = lectures.Where(p => p.Language.LanguageCode == lang.LanguageCode).Take(3).ToArray(),
                Seminars = seminars.Where(p => p.Language.LanguageCode == lang.LanguageCode).Take(3).ToArray(),
                Projects = projects.Where(p => p.Language.LanguageCode == lang.LanguageCode).Take(3).ToArray()
            };

            dBContext.People.Add(person);
            dBContext.SaveChanges();
        }

        private static Biography CopyBiography(string name, Biography biogr)
        {
            return new Biography
            {
                Description = name + biogr.Description
            };
        }

        private static Image CopyImage(Image img)
        {
            return new Image
            {
                ImageName = "Person Foto",
                Image1 = img.Image1,
                ImageTypeExtenction = img.ImageTypeExtenction
            };
        }
    }
}
