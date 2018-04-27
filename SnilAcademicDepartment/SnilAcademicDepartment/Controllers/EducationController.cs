using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class EducationController : Controller
    {
        public EducationController()
        {

        }

        [HttpGet]
        public ActionResult Education()
        {
            ViewBag.Title = "Education";
            return View();
        }

        [HttpGet]
        public ActionResult PageQuickLearning()
        {
            ViewBag.Title = "Quick Learning";
            return View();
        }

        [HttpGet]
        public ActionResult PageSeminars()
        {
            ViewBag.Title = "Seminars";
            return View();
        }

        [HttpGet]
        public ActionResult PageLectures()
        {
            ViewBag.Title = "Lecturs";
            return View();
        }
    }
}