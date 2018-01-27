using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    public interface IPersons
    {
        ActionResult Administration();
        ActionResult MS();
        ActionResult Persons();
        ActionResult PHDs();
        ActionResult Students();
    }
}