using SnilAcademicDepartment.Filters;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            
            // List of availiable cultures.
            var cultures = new List<string>() { "ru", "en", "de" };

            // Check if the list of cultures contains parameter.
            if ( lang.ToLower() == null || !cultures.Contains(lang))
            {
                lang = "en";
            }

            // Save selected culture in the cookie.
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // If the cookie is installed, then we update the values.
            else
            {
                cookie = new HttpCookie("lang")
                {
                    HttpOnly = false,
                    Value = lang,
                    Expires = DateTime.Now.AddHours(10)
                };
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}