using SnilAcademicDepartment.BusinessLogic.Services;
using System.Web.Mvc;

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
        public void GetImage()
        {
            byte[] bytes = imageManager.GetImage();
            var res = new FileContentResult(bytes, "image/jpeg");
            res.ExecuteResult(this.ControllerContext);
        }
    }
}
