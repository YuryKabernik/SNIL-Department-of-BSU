using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
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
        public Task<ActionResult> Persons()
        {
            ViewBag.Title = "Persons";
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
        public Task<ActionResult> Students()
        {
            ViewBag.Title = "Stuedents";
            return Task.FromResult<ActionResult>(View());
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
