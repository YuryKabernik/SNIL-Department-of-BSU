using System.Threading.Tasks;
using System.Web;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ICookieManager
    {
        /// <summary>
        /// Method for creating cookie culture data.
        /// </summary>
        /// <param name="language">Short culture name.</param>
        /// <param name="cookie">Cookie object if exist.</param>
        /// <param name="name">Data alias.</param>
        /// <returns>Returns Cookie object to set user.</returns>
        HttpCookie SetCookieCulture(string language, HttpCookie cookie, string name = "language");

        /// <summary>
        /// Async method for creating cookie culture data.
        /// </summary>
        /// <param name="language">Short culture name.</param>
        /// <param name="cookie">Cookie object if exist.</param>
        /// <param name="name">Data alias.</param>
        /// <returns>Returns Cookie object to set user.</returns>
        Task<HttpCookie> SetCookieCultureAsync(string language, HttpCookie cookie, string name = "language");
    }
}