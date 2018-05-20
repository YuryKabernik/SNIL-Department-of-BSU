using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class BiographyDBInit
    {
        private static string _description = "A biography, or simply bio, is a detailed description of a person's life." +
            " It involves more than just the basic facts like education, work, relationships, and death;" +
            " it portrays a person's experience of these life events. Unlike a profile or curriculum vitae (résumé)," +
            " a biography presents a subject's life story, highlighting various aspects of his or her life, including intimate details of experience," +
            " and may include an analysis of the subject's personality.";

        public static void DBInit(SnilDBContext dBContext, string description, out Biography biography)
        {
            biography = new Biography
            {
                Description = description + _description
            };

            dBContext.Biographies.Add(biography);
            dBContext.SaveChanges();
        }
    }
}
