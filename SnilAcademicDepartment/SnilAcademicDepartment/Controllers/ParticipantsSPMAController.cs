using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
	public class ParticipantsSPMAController : Controller
    {
		private readonly ILogger _logger;
		private readonly ISpmaParticipants _participantsService;

		public ParticipantsSPMAController(ILogger logger, ISpmaParticipants participantsService)
		{
			this._logger = logger;
			this._participantsService = participantsService;
		}

		[HttpGet]
		[Route("participants")]
		public ActionResult ParticipantsPage()
        {
            return View();
        }
    }
}