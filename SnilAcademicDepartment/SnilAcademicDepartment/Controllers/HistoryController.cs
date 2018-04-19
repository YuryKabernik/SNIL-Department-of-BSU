using SnilAcademicDepartment.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class HistoryController : Controller, IHistory
    { 
        public HistoryController()
        {

        }

        [HttpGet]
        public ActionResult History()
        {
            ViewBag.Title = "History";
            return View();
        }

        [HttpGet]
        public ActionResult PageArchive()
        {
            ViewBag.Title = "Archive";
            return View();
        }

        [HttpGet]
        public ActionResult PageIEEE()
        {
            ViewBag.Title = "IEEE";
            return View();
        }

        [HttpGet]
        public ActionResult PageReview()
        {
            ViewBag.Title = "Review";
            return View();
        }

        [HttpGet]
        public ActionResult PageReports()
        {
            ViewBag.Title = "Reports";
            return View();
        }
    }
}