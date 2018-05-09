using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class ImageDBInit
    {
        public static void DBInit(SnilDBContext db, byte[] imageByte, out Image image)
        {
            var preview = new Image()
            {
                ImageName = "Default",
                Image1 = imageByte
            };

            db.Images.Add(preview);
            db.SaveChanges();

            // Set to out.
            image = preview;
        }
    }
}
