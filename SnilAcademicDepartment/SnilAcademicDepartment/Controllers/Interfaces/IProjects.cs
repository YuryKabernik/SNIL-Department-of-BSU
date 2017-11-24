using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    public interface IProjects
    {
        ActionResult PageCurrent();
        ActionResult PageFinished();
        ActionResult PageNew();
        ActionResult Projects();
    }
}