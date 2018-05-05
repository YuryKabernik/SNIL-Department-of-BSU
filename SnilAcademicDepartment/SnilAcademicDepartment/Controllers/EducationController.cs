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
        [Route("Education")]
        public ActionResult Education()
        {
            ViewBag.Title = "Education";
            return View();
        }

        [HttpGet]
        [Route("PageQuickLearning")]
        public ActionResult PageQuickLearning()
        {
            ViewBag.Title = "Quick Learning";
            return View();
        }

        [HttpGet]
        [Route("PageSeminars")]
        public ActionResult PageSeminars()
        {
            ViewBag.Title = "Seminars";
            return View();
        }

        [HttpGet]
        [Route("PageLectures")]
        public ActionResult PageLectures()
        {
            ViewBag.Title = "Lecturs";
            return View();
        }
    }
}