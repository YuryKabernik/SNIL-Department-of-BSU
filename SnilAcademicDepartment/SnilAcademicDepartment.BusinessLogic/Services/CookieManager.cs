using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Web;
using System.Globalization;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public class CookieManager : ICookieManager
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public CookieManager(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        
        /// <summary>
        /// Method of set cookie by user's culture.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="cookie"></param>
        /// <param name="newCookieName"></param>
        /// <returns></returns>
        public HttpCookie SetCookieCulture(string language, HttpCookie cookie, string newCookieName = "language")
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language), "Selected language can't be null.");

            var culture = CultureInfo.GetCultureInfo(language);

            // Save selected culture in the cookie.
            if (cookie != null)
                cookie.Value = language;   // If the cookie is installed, then we update the values.
            else
            {
                cookie = new HttpCookie(newCookieName)
                {
                    HttpOnly = false,
                    Value = language,
                    Expires = DateTime.Now.AddHours(1)
                };
            }
            return cookie;
        }
    }
}
