using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    public interface IHistory
    {
        ActionResult History();
        ActionResult PageArchive();
        ActionResult PageIEEE();
        ActionResult PageReports();
        ActionResult PageReview();
    }
}