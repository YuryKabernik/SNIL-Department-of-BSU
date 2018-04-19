using SnilAcademicDepartment.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{

    [Culture]
    public class ProjectsController : Controller, IProjects
    {
        public ProjectsController()
        {

        }

        [HttpGet]
        public ActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageNew()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageFinished()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageCurrent()
        {
            return View();
        }
    }
}