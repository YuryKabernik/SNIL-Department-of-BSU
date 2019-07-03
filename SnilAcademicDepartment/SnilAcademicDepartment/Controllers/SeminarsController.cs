using NLog;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;
using SnilAcademicDepartment.Properties;
using SnilAcademicDepartment.Resources.EducationResources;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class SeminarsController : Controller
	{
		private readonly ILogger _logger;
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
		public SeminarsController(
			ILogger logger,
			ISNILConfigurationManager configManager,
			IService previewService,
			IEducation educationService,
			ISeminarPreview seminarPreviewService)
		{
			this._logger = logger;
			this._configManager = configManager;
			this._seminarPreviewService = seminarPreviewService;
		}

		[HttpGet]
		[Route("seminars")]
		public async Task<ActionResult> Seminars()
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

			return View("SeminarsPage");
		}
	}
}