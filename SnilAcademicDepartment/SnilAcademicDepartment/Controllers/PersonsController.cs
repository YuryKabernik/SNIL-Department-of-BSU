using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class PersonsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPeople _peopleService;

        /// <summary>
        /// Constructor of the PersonsController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="peopleService"></param>
        public PersonsController(ILogger logger, IPeople peopleService)
        {
            this._logger = logger;
            this._peopleService = peopleService;
        }

        [HttpGet]
        [Route("people")]
        public async Task<ActionResult> Persons()
        {
            IEnumerable<Leader> leaders;

            ViewBag.Title = "Persons";

            try
            {
                leaders = await this._peopleService.GetHallOfFameLeadersAsync(5, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (System.Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Leaders = leaders;

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
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewData.Model = personalInfo;
			ViewBag.Title = string.Format("{0}, {1}",personalInfo.SecoundName, personalInfo.PersonName);
			return View();
        }

        [HttpGet]
        [Route("enrollee")]
        public Task<ActionResult> Enrollee()
        {
            ViewBag.Title = "Enrollee";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("professors")]
        public async Task<ActionResult> ProfessorsPage()
        {
            IEnumerable<Professor> personVMs;

            try
            {
                personVMs = await this._peopleService.GetPersonsByProfessionStatusAsync<Professor>("Professor", Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (System.Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewData["Professors"] = personVMs;
            ViewBag.Title = "Professors";
            return View("Professors");
        }

        [HttpGet]
        [Route("administration")]
        public Task<ActionResult> PageAdministration()
        {
            ViewBag.Title = "Administration";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("students")]
        public async Task<ActionResult> PageStudents()
        {
            IEnumerable<PersonVM> personVMs;

            try
            {
                personVMs = await this._peopleService.GetPersonsByProfessionStatusAsync<PersonVM>("Student", Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (System.Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewData["Students"] = personVMs;
            ViewBag.Title = "Students";
            return View();
        }

        [HttpGet]
        [Route("ms")]
        public async Task<ActionResult> PageMS()
        {
			IEnumerable<MasterOfScience> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByDegreeAsync<MasterOfScience>("MS", Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
			}

            ViewData["MS"] = personVMs;
			ViewBag.Title = "Masters of Science";
			return View();
        }

        [HttpGet]
        [Route("phd")]
        public async Task<ActionResult> PagePHDs()
        {
			IEnumerable<DoctorOfPhilosophy> personVMs;

			try
			{
				personVMs = await this._peopleService.GetPersonsByDegreeAsync<DoctorOfPhilosophy>("PhD", Thread.CurrentThread.CurrentCulture.LCID);
			}
			catch (System.Exception)
			{
				return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
			}

            ViewData["PHD"] = personVMs;
			ViewBag.Title = "Doctors of Philosophy";
			return View();
        }
    }
}
