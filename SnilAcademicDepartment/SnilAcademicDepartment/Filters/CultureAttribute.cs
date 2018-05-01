using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// Culture filter on action executed.
        /// </summary>
        /// <param name="filterContext"> Action executed context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string cultureName = string.Empty;

            try
            {
                // Get language from cookies.
                cultureName = this.GetCookieCulture(filterContext);

                // Get language from route.
                if (string.IsNullOrEmpty(cultureName))
                    cultureName = GetRouteCulture(filterContext);

                // Get language from request headers.
                if (string.IsNullOrEmpty(cultureName))
                    cultureName = this.GetHeaderCulture(filterContext);
            }
            catch (CultureNotFoundException)
            {

            }


            

            if (string.IsNullOrEmpty(cultureName))
                cultureName = "en";

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }

        private static string GetRouteCulture(ActionExecutedContext filterContext)
        {
            return filterContext.RouteData.Values["lang"] as string;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // throw new NotImplementedException("Method is not implemented.");
        }

        /// <summary>
        /// Method of finding a culture in cookies.
        /// </summary>
        /// <param name="filterContext">Base filter context.</param>
        /// <returns>The string of current request culture.</returns>
        private string GetCookieCulture(ActionExecutedContext filterContext)
        {
            // Получаем куки из контекста, которые могут содержать установленную культуру
            var cultureCookie = filterContext.HttpContext.Request.Cookies["language"];

            if (cultureCookie != null)
                return CultureInfo.GetCultureInfo(cultureCookie.Value).Name;
            else
                return null;
        }

        /// <summary>
        /// Method of finding a culture in request headers.
        /// </summary>
        /// <param name="filterContext">Base filter context.</param>
        /// <returns>The string of current request culture.</returns>
        private string GetHeaderCulture(ActionExecutedContext filterContext)
        {
            // Получаем заголовок из запроса, который может содержать установленную культуру
            var userLanguages = filterContext.HttpContext.Request.UserLanguages;

            if (userLanguages != null && userLanguages.Length != 0)
                return CultureInfo.GetCultureInfo(userLanguages[0]).Name;

            return null;
        }
    }
}
