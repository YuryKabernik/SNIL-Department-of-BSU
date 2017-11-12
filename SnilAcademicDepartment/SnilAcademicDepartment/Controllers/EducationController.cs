using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
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
        public ActionResult PageLecturs()
        {
            ViewBag.Title = "Lecturs";
            return View();
        }
    }
}