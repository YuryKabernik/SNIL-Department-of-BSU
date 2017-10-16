using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    public class PersonsController : Controller
    {
        //----------------------------------- All Pages ------------------------------------
        public ActionResult Persons()
        {
            return View();
        }
        public ActionResult Administration()
        {
            return View();
        }
        public ActionResult Students()
        {
            return View();
        }
        public ActionResult Ms()
        {
            return View();
        }
        public ActionResult PHDs()
        {
            return View();
        }
    }
}
