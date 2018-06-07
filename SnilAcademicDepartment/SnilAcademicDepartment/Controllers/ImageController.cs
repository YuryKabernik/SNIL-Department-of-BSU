using System;
using SnilAcademicDepartment.BusinessLogic.Managers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

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
            try
            {
                var image = await imageManager.GetImageAsync(id);
                var res = new FileContentResult(image.Content, MimeMapping.GetMimeMapping(image.ImageTypeExtenction));
                res.ExecuteResult(this.ControllerContext);
            }
            catch (Exception)
            {
                Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/").ExecuteResult(this.ControllerContext);
            }
        }
    }
}
