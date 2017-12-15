using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    internal interface IEducation
    {
        ActionResult Education();
        ActionResult PageQuickLearning();
        ActionResult PageSeminars();
        ActionResult PageLectures();
        
    }
}