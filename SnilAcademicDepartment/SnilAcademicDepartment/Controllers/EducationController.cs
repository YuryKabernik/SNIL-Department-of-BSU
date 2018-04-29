using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class EducationController : Controller
    {
        //----------------------------------- All Pages ------------------------------------
        public ActionResult Education()
        {
            ViewBag.Title = "Education";
            return View();
        }
        public ActionResult PageQuickLearning()
        {
            ViewBag.Title = "Quick Learning";
            return View();
        }
        public ActionResult PageSeminars()
        {
            ViewBag.Title = "Seminars";
            return View();
        }
        public ActionResult PageLectures()
        {
            ViewBag.Title = "Lecturs";
            return View();
        }
    }
}