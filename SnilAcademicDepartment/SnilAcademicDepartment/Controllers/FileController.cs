using System.Web.Mvc;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web;

namespace SnilAcademicDepartment.Controllers
{
    public class FileController : Controller
    {
        private readonly IDataBaseFileManager _fileManager;

        public FileController(IDataBaseFileManager fileManager)
        {
            this._fileManager = fileManager;
        }

        [HttpGet]
        [Route("file")]
        public FileResult GetFileById(int? id)
        {
            if (id == null)
            {
                Redirect(this.Request.UrlReferrer?.AbsolutePath ?? "/");
            }

            var file = this._fileManager.GetFileById((int)id);
            
            string mimeType = MimeMapping.GetMimeMapping(file.FileType);

            var res = new FileContentResult(file.Content, mimeType);
            return res;
        }
    }
}