using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class EducationKeyAreaDBInit
    {
        private static string _discription = "Лекции с подробным описанием плана проведения занятий каждой из дисциплин. Раскрытие темы лекции, основного материала каждого из лекционного занятия, важные определения и формулы. Вы можете ознакомиться с отзывами студентов о зачитанном материале и качестве преподавания сотрудников лаборатории. Также есть возможность ознакомиться с профессианальной деятельностью и заслугами преподавательского состава. ";
        public static void DBInit(SnilDBContext db, string title, string discriptionPrefix, Image image, Language language, List<EducationBlock> educationBlocks)
        {
            var block = new EducationBlock
            {
                Name = title,
                Description = discriptionPrefix + _discription,
                Image1 = image,
                Language = language
            };

            educationBlocks.Add(block);
        }
    }
}
