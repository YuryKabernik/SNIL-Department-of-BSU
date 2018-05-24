using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SnilAcademicDepartment.DataAccess;

namespace SnilAcademicDepartment.BusinessLogic.Managers
{
    public class ImageManager
    {
        private readonly SnilDBContext _snilDbContext;

        public ImageManager(SnilDBContext snilDbContext)
        {
            this._snilDbContext = snilDbContext;
        }

        public async Task<byte[]> GetImageAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id cant be equal or less than zero.");
            }

            var res = await _snilDbContext.Images.Where(p => p.ImageId == id).Select(s => s.Image1).FirstAsync();

            if (res == null)
            {
                throw new FileNotFoundException($"Cant finde file with id : {id}.");
            }

            return res;
        }
    }
}
