using System;
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
            FileContentResult fileResult = null;
            if (id == null)
            {
                Redirect(this.Request.UrlReferrer?.AbsolutePath ?? "/");
            }

            try
            {
                var file = this._fileManager.GetFileById((int)id);

                string mimeType = MimeMapping.GetMimeMapping(file.FileType);

                fileResult  = new FileContentResult(file.Content, mimeType);
            }
            catch (Exception)
            {
                Redirect(this.Request.UrlReferrer?.AbsolutePath ?? "/");
            }

            return fileResult;
        }
    }
}