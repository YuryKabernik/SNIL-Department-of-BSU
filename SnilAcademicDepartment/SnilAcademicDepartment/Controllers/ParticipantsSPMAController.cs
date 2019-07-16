using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using SnilAcademicDepartment.Base;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;

namespace SnilAcademicDepartment.Controllers
{
	[RoutePrefix("{language}")]
	public class ParticipantsSPMAController : SnilBaseController
	{
		private readonly ISpmaParticipants _participantsService;

		/// <summary>
		/// Initializes a new instance of the <see cref="ParticipantsSPMAController"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		/// <param name="participantsService">The participants service.</param>
		public ParticipantsSPMAController(ILogger logger, ISpmaParticipants participantsService) : base(logger)
		{
			this._participantsService = participantsService;
		}

		[HttpGet]
		[Route("participants")]
		public async Task<ActionResult> ParticipantsPage()
        {
			IEnumerable<SpmaStudent> students;
			IEnumerable<SpmaPerson> heads;
			try
			{
				students = await this._participantsService.GetStuffStudents(Thread.CurrentThread.CurrentCulture.LCID);
				heads = await this._participantsService.GetStuffPersonal(Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception ex)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData.Add("students", students);
			ViewData.Add("heads", heads);
			return View("ParticipantsSPMA");
		}

		[HttpGet]
		[Route("spma/student")]
		public async Task<ActionResult> SpmaStudentPersonalPage(int id)
		{
			if (id <= 0)
				return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");

			SpmaStudent personalInfo = null;

			try
			{
				personalInfo = await this._participantsService.GetStuffStudentById(id, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData.Model = personalInfo;
			ViewBag.Title = string.Format("{0}, {1}", personalInfo.SecoundName, personalInfo.FirstName);
			return View("SpmaPersonalPage");
		}

		[HttpGet]
		[Route("spma/stuff")]
		public async Task<ActionResult> SpmaStuffPersonalPage(int id)
		{
			if (id <= 0)
				return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");

			SpmaPerson personalInfo = null;

			try
			{
				personalInfo = await this._participantsService.GetStuffPersonById(id, Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				ViewBag.Title = UnavaliableErrorResource.UnavaliableMessage;
				return View("SorryUnavaliable");
			}

			ViewData.Model = personalInfo;
			ViewBag.Title = string.Format("{0}, {1}", personalInfo.SecoundName, personalInfo.PersonName);
			return View("SpmaPersonalPage");
		}
	}
}