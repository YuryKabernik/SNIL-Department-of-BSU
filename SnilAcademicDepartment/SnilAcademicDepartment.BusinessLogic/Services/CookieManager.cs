using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Web;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    class CookieManager : ICookieManager
    {
        private readonly ILogger _logger;
        private readonly IRepository _repository;

        public CookieManager(ILogger logger, IRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }
        
        public HttpCookie ChangeCulture(string lang, HttpRequestBase requestBase)
        {
            string returnUrl = requestBase.UrlReferrer.AbsolutePath;

            // List of availiable cultures.
            var cultures = new List<string>() { "ru", "en", "de" };

            // Check if the list of cultures contains parameter.
            if (lang.ToLower() == null || !cultures.Contains(lang))
            {
                lang = "en";
            }

            // Save selected culture in the cookie.
            HttpCookie cookie = requestBase.Cookies["lang"];
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
            return cookie;
        }
    }
}
