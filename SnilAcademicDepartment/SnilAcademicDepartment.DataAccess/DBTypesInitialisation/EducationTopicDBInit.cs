using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class EducationTopicDBInit
    {
        public static void DBInit(SnilDBContext db, string topicName, EducationBlock educationBlock)
        {
            var preview = new EducationTopic()
            {
                TopicName = topicName,
                EducationBlock = educationBlock
            };

            db.EducationTopics.Add(preview);
            db.SaveChanges();
        }
    }
}
