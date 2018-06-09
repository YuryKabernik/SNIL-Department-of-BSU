using System;
using System.Web.Mvc;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web;
using System.Threading.Tasks;

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
        public async Task<ActionResult> GetFileById(int? id)
        {
            FileContentResult fileResult = null;
            if (id == null)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            try
            {
                var file = await this._fileManager.GetFileByIdAsync((int)id);

                string mimeType = MimeMapping.GetMimeMapping(file.FileType);

                fileResult  = new FileContentResult(file.Content, mimeType);
            }
            catch (Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            return fileResult;
        }
    }
}