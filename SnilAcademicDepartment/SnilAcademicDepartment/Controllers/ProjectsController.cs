using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;
using SnilAcademicDepartment.Common.Enumerations;
using SnilAcademicDepartment.Properties;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class ProjectsController : Controller
    {
        private readonly ILogger _logger;
		private readonly ISNILConfigurationManager _configManager;
		private readonly IService _previewService;
        private readonly IProjects _projectsService;
        private readonly IProjectsPreview _projectsPreview;

        /// <summary>
        /// Constructor of the ProjectsController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="projectsService"></param>
        public ProjectsController(ILogger logger, ISNILConfigurationManager configManager, IService previewService, IProjects projectsService, IProjectsPreview projectsPreview)
        {
            this._logger = logger;
			this._configManager = configManager;
			this._previewService = previewService;
            this._projectsService = projectsService;
            this._projectsPreview = projectsPreview;
        }

        [HttpGet]
        [Route("projects")]
        public async Task<ActionResult> Projects()
        {
			PreViewModel projectPreview = null;

			IEnumerable<ProjectPreview> currentPreviews = null;
            IEnumerable<ProjectPreview> newPreviews = null;
            IEnumerable<ProjectPreview> finishedPreviews = null;

			var start = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectsPreviewsStartIndexKey);
			var end = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectsPreviewsEndIndexKey);

			try
			{
                // Get project previews.
                projectPreview = await this._previewService.GetPagePreviewAsync("Projects", Thread.CurrentThread.CurrentCulture.LCID);

                currentPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>(ProjectStatusDTO.Current, start, end, Thread.CurrentThread.CurrentCulture.LCID);

                newPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>(ProjectStatusDTO.New, start, end, Thread.CurrentThread.CurrentCulture.LCID);

                finishedPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>(ProjectStatusDTO.Finished, start, end, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception ex)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Preview = projectPreview;

            ViewBag.currentPreviews = currentPreviews;
            ViewBag.newPreviews = newPreviews;
            ViewBag.finishedPreviews = finishedPreviews;

            return View();
        }

        [HttpGet]
        [Route("new")]
        public async Task<ActionResult> PageNew(int id)
        {
            ProjectModel projectModel = null;
            IEnumerable<ProjectPreview> newPreviews = null;

			var start = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectPagePreviewsStartIndexKey);
			var end = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectPagePreviewsEndIndexKey);

			try
			{
                projectModel = this._projectsService.GetProjectById(id, Thread.CurrentThread.CurrentCulture.LCID);

                newPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>(ProjectStatusDTO.New, start, end, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception )
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Title = projectModel.ProjectTitle;
            ViewBag.Project = projectModel;
            ViewBag.Previews = newPreviews;

            return View("ProjectPage");
        }

        [HttpGet]
        [Route("finished")]
        public async Task<ActionResult> PageFinished(int id)
        {
            ProjectModel projectModel = null;
            IEnumerable<ProjectPreview> finishedPreviews = null;

			var start = await  this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectPagePreviewsStartIndexKey);
			var end = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectPagePreviewsEndIndexKey);

			try
			{
                projectModel = this._projectsService.GetProjectById(id, Thread.CurrentThread.CurrentCulture.LCID);

                finishedPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>(ProjectStatusDTO.Finished, start, end, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Title = projectModel.ProjectTitle;
            ViewBag.Project = projectModel;
            ViewBag.Previews = finishedPreviews;

            return View("ProjectPage");
        }

        [HttpGet]
        [Route("current")]
        public async Task<ActionResult> PageCurrent(int id)
        {
            ProjectModel projectModel = null;
            IEnumerable<ProjectPreview> currentPreviews = null;

			var start = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectPagePreviewsStartIndexKey);
			var end = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.ProjectPagePreviewsEndIndexKey);

			try
			{
                projectModel = this._projectsService.GetProjectById(id, Thread.CurrentThread.CurrentCulture.LCID);

                currentPreviews = await this._projectsPreview
                   .GetProjectsPreviewsAsync<ProjectPreview>(ProjectStatusDTO.Current, start, end, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Title = projectModel.ProjectTitle;
            ViewBag.Project = projectModel;
            ViewBag.Previews = currentPreviews;

            return View("ProjectPage");
        }
    }
}