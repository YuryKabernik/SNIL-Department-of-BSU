using System.Threading.Tasks;
using System.Web;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ICookieManager
    {
        /// <summary>
        /// Method sets language cookie by user's culture.
        /// </summary>
        /// <param name="language">User's language.</param>
        /// <param name="cookie">Cookie in request if exists.</param>
        /// <param name="newCookieName">Optional. Name of new cookie.</param>
        /// <returns>New or modifed http cookie object with fixed language.</returns>
        HttpCookie SetCookieCulture(string language, HttpCookie cookie, string name = "language");

        /// <summary>
        /// Async method sets language cookie by user's culture.
        /// </summary>
        /// <param name="language">User's language.</param>
        /// <param name="cookie">Cookie in request if exists.</param>
        /// <param name="newCookieName">Optional. Name of new cookie.</param>
        /// <returns>New or modifed http cookie object with fixed language.</returns>
        Task<HttpCookie> SetCookieCultureAsync(string language, HttpCookie cookie, string name = "language");
    }
}