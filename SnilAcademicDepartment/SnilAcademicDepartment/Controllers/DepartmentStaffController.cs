using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using Resources;
using SnilAcademicDepartment.Base;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;
using SnilAcademicDepartment.Common.Enumerations.DepartmentStaff;
using SnilAcademicDepartment.Properties;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;

namespace SnilAcademicDepartment.Controllers
{
	[RoutePrefix("{language}")]
	public class DepartmentStaffController : SnilBaseController
	{
		private readonly ISNILConfigurationManager _configManager;
		private readonly IPeople _peopleService;

		/// <summary>
		/// Constructor of the PersonsController.
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="peopleService"></param>
		public DepartmentStaffController(ILogger logger, ISNILConfigurationManager configManager, IPeople peopleService) : base(logger)
		{
			this._configManager = configManager;
			this._peopleService = peopleService;
		}

		[HttpGet]
		[Route("department/staff")]
		public async Task<ActionResult> Persons()
		{
			IEnumerable<Leader> leaders = null;
			IEnumerable<Pedagogue> majorStaff = null;
			IEnumerable<Pedagogue> secondaryStaff = null;

			var numberOfLeadersOnHallOfFame = await this._configManager.GetConfigValueIntAsync(SnilConfigurationSectionKeys.NumberOfLeadersOnHallOfFameKey);

			try
			{
				leaders = await this._peopleService.GetHallOfFameLeadersAsync(numberOfLeadersOnHallOfFame, Thread.CurrentThread.CurrentCulture.LCID);
				majorStaff = await this._peopleService.GetPedagogicalStaffAsync(PedagogicalStaffType.Major, Thread.CurrentThread.CurrentCulture.LCID);
				secondaryStaff = await this._peopleService.GetPedagogicalStaffAsync(PedagogicalStaffType.Secondary, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (Exception ex)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return this.View("SorryUnavaliable");
			}

			ViewData["leaders"] = leaders;
			ViewData["majorStaff"] = majorStaff;
			ViewData["secondaryStaff"] = secondaryStaff;
			ViewBag.Title = Resource.Persons;
			return View();
		}

		[HttpGet]
		[Route("person")]
		public async Task<ActionResult> PersonalPage(int id)
		{
			if (id <= 0)
				return this.View("SorryUnavaliable");

			PersonVM personalInfo = null;

			try
			{
				personalInfo = await this._peopleService.GetPersonDescriptionAsync(id, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return this.View("SorryUnavaliable");
			}

			ViewData.Model = personalInfo;
			ViewBag.Title = string.Format("{0}, {1}", personalInfo.SecoundName, personalInfo.PersonName);
			return this.View();
		}
	}
}
