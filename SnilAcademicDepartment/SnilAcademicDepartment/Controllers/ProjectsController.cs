using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{

    [Culture]
    public class ProjectsController : Controller
    {
        public ProjectsController()
        {

        }

        [HttpGet]
        [Route("Projects")]
        public ActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        [Route("New")]
        public ActionResult PageNew()
        {
            return View();
        }

        [HttpGet]
        [Route("Finished")]
        public ActionResult PageFinished()
        {
            return View();
        }

        [HttpGet]
        [Route("Current")]
        public ActionResult PageCurrent()
        {
            return View();
        }
    }
}