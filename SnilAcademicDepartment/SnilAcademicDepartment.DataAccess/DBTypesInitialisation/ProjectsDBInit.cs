using System;
using System.Collections.Generic;
using SnilAcademicDepartment.DataAccess.Models;
using SnilAcademicDepartment.DataAccess.Models.EnumTypes;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class ProjectsDBInit
    {
        private static string _description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt, consequatur delectus totam molestiae, in nam. Pariatur explicabo velit quas tempore rerum voluptas alias doloribus in repudiandae quos commodi asperiores quae esse iure cumque perspiciatis aperiam, expedita provident aspernatur nisi error molestias repellendus. Magnam magni eveniet repudiandae officia fugit ullam facilis unde error earum voluptatum ducimus, ab nemo consequatur dignissimos tenetur perferendis inventore quaerat!";

        private static string _shortDiscription = "Участники лаборатории, преподаватели и студенты кафедры. В данном разделе вы можете ознакомиться с преподавательским составом лаборатории и кафедры, а так же с самыми активными студентами и их достижениями в обучении и научной деятельности. Также вы можете ознакомиться с лучшими сотрудниками месяца.";

        public static void DBInit(
             SnilDBContext db,
             int commonId,
             string title,
             string discriptionPrefix,
			 ProjectStatus projectStatus,
             DateTime? dataTime,
             Language language,
             Image image,
             Document document,
            List<Project> projects )
        {
            var project = new Project()
            {
                CommonID = commonId,
                ProjectName = title,
                ShortDescription = discriptionPrefix + _shortDiscription,
                Description = discriptionPrefix + _description,
                Status = projectStatus.ToString(),
                CreationDate = dataTime,
                Language = language,
                Image = image,
                Document = document
            };

            projects.Add(project);

            db.Projects.Add(project);
            db.SaveChanges();
        }
    }
}
