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
        [Route("Persons")]
        public ActionResult Persons()
        {
            ViewBag.Title = "Persons";
            return View();
        }

        [HttpGet]
        [Route("Administration")]
        public ActionResult Administration()
        {
            ViewBag.Title = "Administration";
            return View();
        }

        [HttpGet]
        [Route("Students")]
        public ActionResult Students()
        {
            ViewBag.Title = "Stuedents";
            return View();
        }

        [HttpGet]
        [Route("MS")]
        public ActionResult MS()
        {
            ViewBag.Title = "Master of Science";
            return View();
        }

        [HttpGet]
        [Route("PHDs")]
        public ActionResult PHDs()
        {
            ViewBag.Title = "PHDs";
            return View();
        }
    }
}
