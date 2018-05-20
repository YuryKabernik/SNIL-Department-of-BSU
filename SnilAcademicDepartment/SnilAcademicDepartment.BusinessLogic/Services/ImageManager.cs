using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnilAcademicDepartment.DataAccess;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class ImageManager
    {
        private readonly SnilDBContext snilDBContext;

        public ImageManager(SnilDBContext snilDBContext)
        {
            this.snilDBContext = snilDBContext;
        }

        public byte[] GetImage()
        {
            return snilDBContext.Images.First().Image1;
        }
    }
}
