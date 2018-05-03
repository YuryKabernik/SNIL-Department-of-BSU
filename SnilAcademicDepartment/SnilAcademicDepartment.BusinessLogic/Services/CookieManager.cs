using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System;
using System.Web;
using System.Globalization;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class CookieManager : ICookieManager
    {
        private readonly ILogger _logger;

        public CookieManager(ILogger logger)
        {
            this._logger = logger;
        }
        
        /// <summary>
        /// Method sets language cookie by user's culture.
        /// </summary>
        /// <param name="language">User's language.</param>
        /// <param name="cookie">Cookie in request if exists.</param>
        /// <param name="newCookieName">Optional. Name of new cookie.</param>
        /// <returns>New or modifed http cookie object with fixed language.</returns>
        public HttpCookie SetCookieCulture(string language, HttpCookie cookie, string newCookieName = "language")
        {
            if (string.IsNullOrEmpty(language) || string.IsNullOrWhiteSpace(language))
                throw new ArgumentException(nameof(language), "Selected language can't be null.");

            var culture = CultureInfo.GetCultureInfo(language);

            // Save selected culture in the cookie.
            if (cookie != null)
                cookie.Value = culture.Name;   // If the cookie is installed, then we update the values.
            else
            {
                cookie = new HttpCookie(newCookieName)
                {
                    HttpOnly = false,
                    Value = culture.Name,
                    Expires = DateTime.Now.AddHours(1)
                };
            }
            return cookie;
        }
    }
}
