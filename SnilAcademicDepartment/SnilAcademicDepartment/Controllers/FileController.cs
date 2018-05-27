using System.Web.Mvc;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Net.Mime;

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
        public ActionResult GetFileById(int? id)
        {
            if (id == null)
            {
                Redirect(this.Request.UrlReferrer.AbsolutePath);
            }

            var file = this._fileManager.GetFileById((int)id);
            var stream = new ContentInfo(file.Content);

            string fileName = file.Name;
            string mimeType = "";
            
            var res = File(file.Content, "", fileName);
            return res;
        }
    }
}