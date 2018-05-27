using System.IO;

namespace SnilAcademicDepartment.DataAccess.DBTypesInitialisation
{
    public static class ImageDBInit
    {
        public static void DBInit(SnilDBContext db, byte[] imageByte, string imgPath, out Image image)
        {
            image = new Image()
            {
                ImageName = "Default",
                Image1 = imageByte,
                ImageTypeExtenction = GetImageExtenction(imgPath)
            };

            db.Images.Add(image);
            db.SaveChanges();
        }

        private static string GetImageExtenction(string imgPath)
        {
            var info = new FileInfo(imgPath);
            return info.Extension;
        }
    }
}
