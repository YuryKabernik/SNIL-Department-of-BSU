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
        [Route("Persons")]
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
        [Route("PersonalPage")]
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

            return View();
        }

        [HttpGet]
        [Route("Enrollee")]
        public Task<ActionResult> Enrollee()
        {
            ViewBag.Title = "Enrollee";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("Professors")]
        public Task<ActionResult> Professors()
        {
            ViewBag.Title = "Professors";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("Administration")]
        public Task<ActionResult> Administration()
        {
            ViewBag.Title = "Administration";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("Students")]
        public async Task<ActionResult> StudentsAsync()
        {
            IEnumerable<PersonVM> personVMs;

            try
            {
                personVMs = await this._peopleService.GetPersonsByDegreeAsync("Student", Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (System.Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewData["Students"] = personVMs;
            ViewBag.Title = "Students";
            return View("PageStudents");
        }

        [HttpGet]
        [Route("MS")]
        public Task<ActionResult> MS()
        {
            ViewBag.Title = "Master of Science";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("PHDs")]
        public Task<ActionResult> PHDs()
        {
            ViewBag.Title = "PHDs";
            return Task.FromResult<ActionResult>(View());
        }
    }
}
