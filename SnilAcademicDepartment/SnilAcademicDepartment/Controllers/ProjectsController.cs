using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{

    [Culture]
    public class ProjectsController : Controller
    {
        //----------------------------------- All Pages ------------------------------------
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult PageNew()
        {
            return View();
        }
        public ActionResult PageFinished()
        {
            return View();
        }
        public ActionResult PageCurrent()
        {
            return View();
        }
    }
}