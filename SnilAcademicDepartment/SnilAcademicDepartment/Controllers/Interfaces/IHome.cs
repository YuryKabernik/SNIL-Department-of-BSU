using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    public interface IHome
    {
        ActionResult About();
        ActionResult ChangeCulture(string lang);
        ActionResult Contact();
        ActionResult Index();
    }
}