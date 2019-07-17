using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using SnilAcademicDepartment.Base;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Interfaces.API;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;
using SnilAcademicDepartment.Properties;
using SnilAcademicDepartment.Resources.EducationResources;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;

namespace SnilAcademicDepartment.Controllers
{
	[RoutePrefix("{language}")]
	public class EducationController : SnilBaseController
	{
		private readonly IService _previewService;
		private readonly IEducation _educationService;
		private readonly IDiplomasApiService _diplomasApiService;
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
			ISeminarPreview seminarPreviewService,
			IDiplomasApiService diplomasApiService) : base(logger)
		{
			this._configManager = configManager;
			this._previewService = previewService;
			this._educationService = educationService;
			this._diplomasApiService = diplomasApiService;
			this._lecturePreviewService = lecturePreviewService;
			this._seminarPreviewService = seminarPreviewService;
		}

		[HttpGet]
		[Route("education")]
		public async Task<ActionResult> Education()
		{
			int numberOfElements = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.NumberOfKeyAreasOnEducationPageKey);

			PreViewModel viewModel = await this._previewService.GetPagePreviewAsync("Education", Thread.CurrentThread.CurrentCulture.LCID);
			List<EducationBlockModel> blockCollection = await this._educationService.GetKeyAreasAsync(numberOfElements, Thread.CurrentThread.CurrentCulture.LCID);

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
		[Route("diploma")]
		public async Task<ActionResult> PageDiploma()
		{
			IEnumerable<UiDiploma> viewModel = null;

			try
			{
				viewModel = await this._diplomasApiService.GetDiplomas(Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (Exception ex)
			{
				string errMessage = $"An exception error occured in PageDiploma with the stack trace: {ex.StackTrace}." +
					$"An inner exception stack trace: {ex.InnerException.StackTrace}";

				this._logger.Error(ex, errMessage);

				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return this.View("~/Views/Error/SorryUnavaliable.cshtml");
			}

			ViewData.Add("diplomas", viewModel);
			return View("Diplomas");
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
			catch (Exception ex)
			{
				string errMessage = $"An exception error occured in PageLectures with the stack trace: {ex.StackTrace}." +
					$"An inner exception stack trace: {ex.InnerException.StackTrace}";

				this._logger.Error(ex, errMessage);

				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return this.View("~/Views/Error/SorryUnavaliable.cshtml");
			}

			ViewBag.Title = "Lections";
			ViewBag.EducationResourseTitle = EducationResource.Lectures;
			ViewBag.Components = lecturePreviewsModels;

			return View("EducationBlockPage");
		}
	}
}