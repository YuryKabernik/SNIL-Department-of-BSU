using System;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    public class CookiesController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICookieManager _cookieManager;

        public CookiesController()
        {

        }

        public CookiesController(ILogger logger, ICookieManager cookieManager)
        {
            this._logger = logger;
            this._cookieManager = cookieManager;
        }

        [HttpPost]
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;

            // List of availiable cultures.
            var cultures = new List<string>() { "ru", "en", "de" };

            // Check if the list of cultures contains parameter.
            if (lang.ToLower() == null || !cultures.Contains(lang))
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