using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;
using SnilAcademicDepartment.Properties;
using Resources;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;

namespace SnilAcademicDepartment.Controllers
{
	[RoutePrefix("{language}")]
	public class DepartmentStaffController : Controller
	{
		private readonly ILogger _logger;
		private readonly ISNILConfigurationManager _configManager;
		private readonly IPeople _peopleService;

		/// <summary>
		/// Constructor of the PersonsController.
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="peopleService"></param>
		public DepartmentStaffController(ILogger logger, ISNILConfigurationManager configManager, IPeople peopleService)
		{
			this._logger = logger;
			this._configManager = configManager;
			this._peopleService = peopleService;
		}

		[HttpGet]
		[Route("people")]
		public async Task<ActionResult> Persons()
		{
			IEnumerable<Leader> leaders = null;

			var numberOfLeadersOnHallOfFame = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.NumberOfLeadersOnHallOfFameKey);

			try
			{
				leaders = await this._peopleService.GetHallOfFameLeadersAsync(numberOfLeadersOnHallOfFame, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewBag.Leaders = leaders;
			ViewBag.Title = Resource.Persons;
			return View();
		}

		[HttpGet]
		[Route("personalpage")]
		public async Task<ActionResult> PersonalPage(int id)
		{
			if (id <= 0)
				return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");

			PersonVM personalInfo = null;

			try
			{
				personalInfo = await this._peopleService.GetPersonDescriptionAsync(id, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData.Model = personalInfo;
			ViewBag.Title = string.Format("{0}, {1}", personalInfo.SecoundName, personalInfo.PersonName);
			return View();
		}
	}
}
