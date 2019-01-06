using System;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;
using System.Threading;
using System.Collections.Generic;
using Resources.EducationResources;
using SnilAcademicDepartment.Properties;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Linq;
using System.Threading.Tasks;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class EducationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;
        private readonly IEducation _educationService;
        private readonly ILecturePreview _lecturePreviewService;
        private readonly ISeminarPreview _seminarPreviewService;
		private readonly ISNILConfigurationManager _configManager;

		/// <summary>
		/// Constructor of the EducationController.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="configManager">The configuration manager.</param>
		/// <param name="previewService">The preview service.</param>
		/// <param name="educationService">The education service.</param>
		/// <param name="lecturePreviewService">The lecture preview service.</param>
		/// <param name="seminarPreviewService">The seminar preview service.</param>
		public EducationController(
            ILogger logger,
            ISNILConfigurationManager configManager,
			IService previewService, 
            IEducation educationService, 
            ILecturePreview lecturePreviewService,
            ISeminarPreview seminarPreviewService)
        {
            this._logger = logger;
			this._configManager = configManager;
			this._previewService = previewService;
            this._educationService = educationService;
            this._lecturePreviewService = lecturePreviewService;
            this._seminarPreviewService = seminarPreviewService;
        }

        [HttpGet]
        [Route("education")]
        public async Task<ActionResult> Education()
        {
            PreViewModel viewModel = null;
            List<EducationBlockModel> blockCollection = null;

			var numberOfElements = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.NumberOfKeyAreasOnEducationPageKey);

            try
            {
                // Get page preview data.
                viewModel = await this._previewService.GetPagePreviewAsync("Education", Thread.CurrentThread.CurrentCulture.LCID);

                // Get educatio key areas.
                blockCollection = await this._educationService.GetKeyAreasAsync(numberOfElements, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Sorry, but education page is not avaliable now :( \n Try again later!";
                return View("Error");
            }

            int i = 1;
            foreach (var item in blockCollection)
            {
                item.ActionId = i++;
            }

            ViewData.Add("viewModel", viewModel);
			ViewData.Add("blockModel", blockCollection);
            return View();
        }

        [HttpGet]
        [Route("learning")]
        public async Task<ActionResult> PageQuickLearning()
        {
            EducationBlockModel viewModel = null;

			var numberOfElements = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.NumberOfQuickLearningBlocksOnPageKey);

			try
			{
                viewModel = await this._educationService.GetEducationBlockByIdAsync(numberOfElements, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception)
            {

				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

            ViewBag.Title = "Quick Learning";
            ViewBag.EducationResourseTitle = EducationResource.QuickLearning;
            ViewBag.Components = viewModel;

            return View("EducationBlockPage");
        }

        [HttpGet]
        [Route("seminars")]
        public async Task<ActionResult> PageSeminars()
        {
            IEnumerable<IGrouping<int, SeminarPreview>> seninarsPreviewsModels = null;

			var numberOfSeminars = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.NumberOfSeminarsOnPageSeminarsKey);

			try
			{
                seninarsPreviewsModels = await this._seminarPreviewService.GetSeminarPreviewsAsync<SeminarPreview>(numberOfSeminars, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

            ViewBag.Title = "Seminars";
            ViewBag.EducationResourseTitle = EducationResource.Seminars;
            ViewBag.Components = seninarsPreviewsModels;

            return View("EducationBlockPage");
        }

        [HttpGet]
        [Route("lections")]
        public async Task<ActionResult> PageLectures()
        {
            IEnumerable<LecturePreview> lecturePreviewsModels = null;

			var numberOfLectures = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.NumberOfLecturesOnPageLecturesKey);

			try
			{
                lecturePreviewsModels = await this._lecturePreviewService.GetLecturePreviewsAsync<LecturePreview>(numberOfLectures, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

            ViewBag.Title = "Lections";
            ViewBag.EducationResourseTitle = EducationResource.Lectures;
            ViewBag.Components = lecturePreviewsModels;

            return View("EducationBlockPage");
        }
    }
}