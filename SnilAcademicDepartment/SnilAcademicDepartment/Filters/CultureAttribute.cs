using System.Globalization;
using System.Threading;
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
                    cultureName = this.GetRouteCulture(filterContext);

                // Get language from request headers.
                if (string.IsNullOrEmpty(cultureName))
                    cultureName = this.GetHeaderCulture(filterContext);
            }
            catch (CultureNotFoundException)
            {
                cultureName = "en";
            }

            if (string.IsNullOrEmpty(cultureName))
                cultureName = "en";

            // Set culture if it's not user custom culture.
            this.SetThreadCulture(cultureName);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // throw new NotImplementedException("Method is not implemented.");
        }

        /// <summary>
        /// Method of finding culture in cookies.
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
        /// Method of getting culture in route.
        /// </summary>
        /// <param name="filterContext">Base filter context.</param>
        /// <returns>The string of current request culture.</returns>
        private string GetRouteCulture(ActionExecutedContext filterContext)
        {
            var routeLanguage = filterContext.RouteData.Values["language"] as string;

            if (!string.IsNullOrEmpty(routeLanguage))
                return CultureInfo.GetCultureInfo(routeLanguage).Name;

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

        /// <summary>
        /// Sets user's culture or default culture to thread.
        /// </summary>
        /// <param name="cultureName">Culture to set in current Thread.</param>
        private void SetThreadCulture(string cultureName)
        {
            var isCustomCulture = new CultureInfo(cultureName).CultureTypes.HasFlag(CultureTypes.UserCustomCulture);

            if (!isCustomCulture)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en");
            }
        }
    }
}
