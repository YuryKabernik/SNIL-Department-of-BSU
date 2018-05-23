using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<byte[]> GetImageAsync(int id)
        {
            var res = await snilDBContext.Images.Where(p => p.ImageId == id).Select(s => s.Image1).FirstAsync();

            return res;
        }
    }
}
