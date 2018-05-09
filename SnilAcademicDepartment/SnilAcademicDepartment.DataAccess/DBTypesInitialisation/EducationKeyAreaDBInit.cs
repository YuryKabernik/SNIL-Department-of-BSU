using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class EducationKeyAreaDBInit
    {
        public static void DBInit(SnilDBContext db, string title, string description, Image image, Language language, ICollection<EducationTopic> educationTopics)
        {
            var block = new EducationBlock
            {
                Name = title,
                Description = description,
                Image1 = image,
                Language = language,
                EducationTopics = educationTopics
            };
        }
    }
}
