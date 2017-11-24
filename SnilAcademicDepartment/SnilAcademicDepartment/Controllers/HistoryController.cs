﻿using SnilAcademicDepartment.Filters;
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
        //----------------------------------- All Pages ------------------------------------
        public ActionResult History()
        {
            ViewBag.Title = "History";
            return View();
        }
        public ActionResult PageArchive()
        {
            ViewBag.Title = "Archive";
            return View();
        }
        public ActionResult PageIEEE()
        {
            ViewBag.Title = "IEEE";
            return View();
        }
        public ActionResult PageReview()
        {
            ViewBag.Title = "Review";
            return View();
        }
        public ActionResult PageReports()
        {
            ViewBag.Title = "Reports";
            return View();
        }
    }
}