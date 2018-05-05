using System;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace SnilAcademicDepartment.Controllers
{
    public class CookiesController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICookieManager _cookieManager;

        public CookiesController(ILogger logger, ICookieManager cookieManager)
        {
            this._logger = logger;
            this._cookieManager = cookieManager;
        }

        /// <summary>
        /// Method for changing UI culture by inserted language.
        /// </summary>
        /// <param name="lang">User's language.</param>
        /// <returns>Redirect to previouse page with new language.</returns>
        [HttpPost]
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            HttpCookie cookie = null;

            try
            {
                var requestCookie = this.Request.Cookies["language"];
                cookie = this._cookieManager.SetCookieCulture(lang, requestCookie);
            }
            catch (CultureNotFoundException)
            {
                return this.Redirect(returnUrl);
            }
            catch (Exception)
            {
                return this.Redirect(returnUrl);
            }

            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }
    }
}