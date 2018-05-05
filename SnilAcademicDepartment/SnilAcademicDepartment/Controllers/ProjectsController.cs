using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{

    [Culture]
    public class ProjectsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IProjects _projectsService;

        /// <summary>
        /// Constructor of the ProjectsController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="projectsService"></param>
        public ProjectsController(ILogger logger, IProjects projectsService)
        {
            this._logger = logger;
            this._projectsService = projectsService;
        }

        [HttpGet]
        public ActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageNew()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageFinished()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageCurrent()
        {
            return View();
        }
    }
}