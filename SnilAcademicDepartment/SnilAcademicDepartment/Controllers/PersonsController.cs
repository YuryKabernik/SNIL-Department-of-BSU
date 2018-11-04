using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using SnilAcademicDepartment.Resources.PersonsResources;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;
using SnilAcademicDepartment.Properties;
using Resources;
using SnilAcademicDepartment.Common.Enumerations;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;

namespace SnilAcademicDepartment.Controllers
{
	[RoutePrefix("{language}")]
	public class PersonsController : Controller
	{
		private readonly ILogger _logger;
		private readonly ISNILConfigurationManager _configManager;
		private readonly IPeople _peopleService;

		/// <summary>
		/// Constructor of the PersonsController.
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="peopleService"></param>
		public PersonsController(ILogger logger, ISNILConfigurationManager configManager, IPeople peopleService)
		{
			this._logger = logger;
			this._configManager = configManager;
			this._peopleService = peopleService;
		}

		[HttpGet]
		[Route("people")]
		public async Task<ActionResult> Persons()
		{
			IEnumerable<Leader> leaders;

			var numberOfLeadersOnHallOfFame = this._configManager.GetConfigValueInt(SnilConfigurationSectionKeys.NumberOfLeadersOnHallOfFameKey);

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

		[HttpGet]
		[Route("enrollee")]
		public async Task<ActionResult> Enrollee()
		{
			IEnumerable<Professor> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByProfessionStatusAsync<Professor>(ProfessionStatusEnum.Professor, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData["Professors"] = personVMs;
			ViewBag.Title = PersonsResource.Abitur;
			return View("Enrollee");
		}

		[HttpGet]
		[Route("professors")]
		public async Task<ActionResult> ProfessorsPage()
		{
			IEnumerable<Professor> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByProfessionStatusAsync<Professor>(ProfessionStatusEnum.Professor, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData["Professors"] = personVMs;
			ViewBag.Title = PersonsResource.Professors;
			return View("Professors");
		}

		[HttpGet]
		[Route("administration")]
		public async Task<ActionResult> PageAdministration()
		{
			IEnumerable<Administrator> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByProfessionStatusAsync<Administrator>(ProfessionStatusEnum.Administrator, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData["Administrators"] = personVMs;
			ViewBag.Title = PersonsResource.Administration;
			return View();
		}

		[HttpGet]
		[Route("students")]
		public async Task<ActionResult> PageStudents()
		{
			IEnumerable<PersonVM> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByProfessionStatusAsync<PersonVM>(ProfessionStatusEnum.Student, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData["Students"] = personVMs;
			ViewBag.Title = PersonsResource.Students;
			return View();
		}

		[HttpGet]
		[Route("ms")]
		public async Task<ActionResult> PageMS()
		{
			IEnumerable<MasterOfScience> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByDegreeAsync<MasterOfScience>(DegreeEnum.MS, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData["MS"] = personVMs;
			ViewBag.Title = PersonsResource.MS;
			return View();
		}

		[HttpGet]
		[Route("phd")]
		public async Task<ActionResult> PagePHDs()
		{
			IEnumerable<DoctorOfPhilosophy> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByDegreeAsync<DoctorOfPhilosophy>(DegreeEnum.Phd, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData["PHD"] = personVMs;
			ViewBag.Title = PersonsResource.PhD;
			return View();
		}
	}
}
