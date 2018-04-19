using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Filters
{
    public class CultureAttribute : FilterAttribute, IActionFilter
    {
        // Список культур
        public readonly List<string> cultureCollection = new List<string>() { "en", "ru", "de" };

        /// <summary>
        /// Culture filter on action executed culture.
        /// </summary>
        /// <param name="filterContext"> Action executed context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var cultureName = this.CheckCookieCulture(filterContext.HttpContext);

            if (string.IsNullOrEmpty(cultureName))
            {
                cultureName = this.CheckHeaderCulture(filterContext.HttpContext);
            }

            if (string.IsNullOrEmpty(cultureName))
            {
                cultureName = "en";
            }

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
            string currentCulture = string.Empty;
            
            // Получаем куки из контекста, которые могут содержать установленную культуру
            var cultureCookie = httpContext.Request.Cookies["lang"];

            if (cultureCookie != null)
                currentCulture = cultureCookie.Value;
            else
                return null;

            // Поиск культуры из списка культур
            if (!cultureCollection.Contains(currentCulture))
            {
                return null;
            }

            return currentCulture;
        }

        /// <summary>
        /// Method of finding a culture in request headers.
        /// </summary>
        /// <param name="httpContext">Base request context.</param>
        /// <returns>The string of current request culture.</returns>
        private string CheckHeaderCulture(HttpContextBase httpContext)
        {
            var currentCulture = string.Empty;

            // Получаем заголовок из запроса, который может содержать установленную культуру
            var cultureHeader = httpContext.Request.Headers["Accept-Language"];

            if (!string.IsNullOrEmpty(cultureHeader))
                currentCulture = cultureHeader;

            // Поиск культуры из списка культур
            foreach (var lang in cultureCollection)
            {
                if (currentCulture.Contains(lang))
                {
                    return lang;
                }
            }

            return currentCulture;
        }
    }
}
