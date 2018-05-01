using System.Web;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ICookieManager
    {
        HttpCookie SetCookieCulture(string language, HttpCookie cookie, string name = "language");
    }
}