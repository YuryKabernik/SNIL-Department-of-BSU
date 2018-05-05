using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class HistoryController : Controller
    { 
        public HistoryController()
        {

        }

        [HttpGet]
        [Route("History")]
        public ActionResult History()
        {
            ViewBag.Title = "History";
            return View();
        }

        [HttpGet]
        [Route("PageArchive")]
        public ActionResult PageArchive()
        {
            ViewBag.Title = "Archive";
            return View();
        }

        [HttpGet]
        [Route("PageIEEE")]
        public ActionResult PageIEEE()
        {
            ViewBag.Title = "IEEE";
            return View();
        }

        [HttpGet]
        [Route("PageReview")]
        public ActionResult PageReview()
        {
            ViewBag.Title = "Review";
            return View();
        }

        [HttpGet]
        [Route("PageReports")]
        public ActionResult PageReports()
        {
            ViewBag.Title = "Reports";
            return View();
        }
    }
}