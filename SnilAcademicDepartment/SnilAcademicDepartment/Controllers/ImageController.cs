using SnilAcademicDepartment.BusinessLogic.Managers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Mime;

namespace SnilAcademicDepartment.Controllers
{
    public class ImageController : Controller
    {
        private readonly ImageManager imageManager;

        public ImageController(ImageManager imageManager)
        {
            this.imageManager = imageManager;
        }

        [HttpGet]
        [Route("image")]
        public async Task GetImage(int id)
        {
            byte[] bytes = await  imageManager.GetImageAsync(id);
            var res = new FileContentResult(bytes, System.Net.Mime.MediaTypeNames.Image.Gif);
            res.ExecuteResult(this.ControllerContext);
        }
    }
}
