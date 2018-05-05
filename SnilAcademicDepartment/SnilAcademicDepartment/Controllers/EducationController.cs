using NLog;
using SnilAcademicDepartment.Filters;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class EducationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEducation _educationService;

        /// <summary>
        /// Constructor of the EducationController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="educationService"></param>
        public EducationController(ILogger logger, IEducation educationService)
        {
            this._logger = logger;
            this._educationService = educationService;
        }

        [HttpGet]
        public ActionResult Education()
        {
            ViewBag.Title = "Education";
            return View();
        }

        [HttpGet]
        public ActionResult PageQuickLearning()
        {
            ViewBag.Title = "Quick Learning";
            return View();
        }

        [HttpGet]
        public ActionResult PageSeminars()
        {
            ViewBag.Title = "Seminars";
            return View();
        }

        [HttpGet]
        public ActionResult PageLectures()
        {
            ViewBag.Title = "Lecturs";
            return View();
        }
    }
}