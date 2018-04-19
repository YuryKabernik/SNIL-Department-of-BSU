using SnilAcademicDepartment.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class PersonsController : Controller
    {
        //----------------------------------- All Pages ------------------------------------
        public ActionResult Persons()
        {
            ViewBag.Title = "Persons";
            return View();
        }
        public ActionResult Administration()
        {
            ViewBag.Title = "Administration";
            return View();
        }
        public ActionResult Students()
        {
            ViewBag.Title = "Stuedents";
            return View();
        }
        public ActionResult MS()
        {
            ViewBag.Title = "MS";
            return View();
        }
        public ActionResult PHDs()
        {
            ViewBag.Title = "PHDs";
            return View();
        }
    }
}
