using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class PersonsController : Controller
    {
        public PersonsController()
        {

        }

        [HttpGet]
        public ActionResult Persons()
        {
            ViewBag.Title = "Persons";
            return View();
        }

        [HttpGet]
        public ActionResult Administration()
        {
            ViewBag.Title = "Administration";
            return View();
        }

        [HttpGet]
        public ActionResult Students()
        {
            ViewBag.Title = "Stuedents";
            return View();
        }

        [HttpGet]
        public ActionResult MS()
        {
            ViewBag.Title = "MS";
            return View();
        }

        [HttpGet]
        public ActionResult PHDs()
        {
            ViewBag.Title = "PHDs";
            return View();
        }
    }
}
