using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// Culture filter on action executed culture.
        /// </summary>
        /// <param name="filterContext"> Action executed context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var cultureName = this.CheckCookieCulture(filterContext.HttpContext);

            // Get language from cookies if route data is empty and cookies not empty too.
            if (string.IsNullOrEmpty(cultureName))
                cultureName = filterContext.RouteData.Values["lang"] as string;

            if (string.IsNullOrEmpty(cultureName))
                cultureName = this.CheckHeaderCulture(filterContext.HttpContext);

            if (string.IsNullOrEmpty(cultureName))
                cultureName = "en";

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // throw new NotImplementedException("Method is not implemented.");
        }

        /// <summary>
        /// Method of finding a culture in cookies.
        /// </summary>
        /// <param name="httpContext">Base request context.</param>
        /// <returns>The string of current request culture.</returns>
        private string CheckCookieCulture(HttpContextBase httpContext)
        {
            // Получаем куки из контекста, которые могут содержать установленную культуру
            var cultureCookie = httpContext.Request.Cookies["language"];

            if (cultureCookie != null)
                return CultureInfo.GetCultureInfo(cultureCookie.Value).Name;
            else
                return null;
        }

        /// <summary>
        /// Method of finding a culture in request headers.
        /// </summary>
        /// <param name="httpContext">Base request context.</param>
        /// <returns>The string of current request culture.</returns>
        private string CheckHeaderCulture(HttpContextBase httpContext)
        {
            // Получаем заголовок из запроса, который может содержать установленную культуру
            var userLanguages = httpContext.Request.UserLanguages;

            if (userLanguages != null && userLanguages.Length != 0)
                return CultureInfo.GetCultureInfo(userLanguages[0]).Name;

            return null;
        }
    }
}
