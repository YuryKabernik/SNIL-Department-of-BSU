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
        public ActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageNew()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageFinished()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageCurrent()
        {
            return View();
        }
    }
}