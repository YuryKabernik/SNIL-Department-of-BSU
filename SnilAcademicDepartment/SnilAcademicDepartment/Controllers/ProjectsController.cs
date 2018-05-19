using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class ProjectsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;
        private readonly IProjects _projectsService;

        /// <summary>
        /// Constructor of the ProjectsController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="projectsService"></param>
        public ProjectsController(ILogger logger,IService previewService, IProjects projectsService)
        {
            this._logger = logger;
            this._previewService = previewService;
            this._projectsService = projectsService;
        }

        [HttpGet]
        [Route("Projects")]
        public ActionResult Projects()
        {
            PreViewModel projectPreview = null;

            IEnumerable<ProjectModel> currentPreviews = null;
            IEnumerable<ProjectModel> newPreviews = null;
            IEnumerable<ProjectModel> finishedtPreviews = null;

            try
            {
                // Get project preview.
                projectPreview = this._previewService.GetPagePreview("Projects", Thread.CurrentThread.CurrentCulture.LCID);

                currentPreviews = this._projectsService.GetProjects("Current", 0, 3, Thread.CurrentThread.CurrentCulture.LCID);
                newPreviews = this._projectsService.GetProjects("New", 0, 3, Thread.CurrentThread.CurrentCulture.LCID);
                finishedtPreviews = this._projectsService.GetProjects("Finished", 0, 3, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception ex)
            {

                throw;
            }

            return View();
        }

        [HttpGet]
        [Route("New")]
        public ActionResult PageNew(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("Finished")]
        public ActionResult PageFinished(int id)
        {
            return View();
        }

        [HttpGet]
        [Route("Current")]
        public ActionResult PageCurrent(int id)
        {
            return View();
        }
    }
}