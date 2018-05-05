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
            string returnUrl = null;
            HttpCookie cookie = null;

            try
            {
                var requestCookie = this.Request.Cookies["language"];
                cookie = this._cookieManager.SetCookieCulture(lang, requestCookie);

                returnUrl = GenerateReturnUrl(cookie); // Get return Url.
            }
            catch (CultureNotFoundException)
            {
                returnUrl = Request.UrlReferrer.AbsolutePath;
                return this.Redirect(returnUrl);
            }
            catch(IndexOutOfRangeException)
            {
                returnUrl = Request.UrlReferrer.AbsolutePath;
            }
            catch (Exception)
            {
                returnUrl = Request.UrlReferrer.AbsolutePath;
                return this.Redirect(returnUrl);
            }

            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        /// <summary>
        /// Reset first segment("language") wich is not "/" of the Url.
        /// </summary>
        /// <param name="cookie">Cookie with new culture data.</param>
        /// <returns>Returns new return Url.</returns>
        private string GenerateReturnUrl(HttpCookie cookie)
        {
            string returnUrl;
            var segm = Request.UrlReferrer.Segments;
            segm.SetValue(cookie.Value, 1);

            returnUrl = string.Join<string>("/", segm).Remove(0,1);
            return returnUrl;
        }
    }
}