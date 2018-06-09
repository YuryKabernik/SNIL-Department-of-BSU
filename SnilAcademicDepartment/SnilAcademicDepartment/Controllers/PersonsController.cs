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
        public async Task<ActionResult> Persons()
        {
            ViewBag.Title = "Persons";
            return View();
        }

        [HttpGet]
        [Route("Administration")]
        public async Task<ActionResult> Administration()
        {
            ViewBag.Title = "Administration";
            return View();
        }

        [HttpGet]
        [Route("Students")]
        public async Task<ActionResult> Students()
        {
            ViewBag.Title = "Stuedents";
            return View();
        }

        [HttpGet]
        [Route("MS")]
        public async Task<ActionResult> MS()
        {
            ViewBag.Title = "Master of Science";
            return View();
        }

        [HttpGet]
        [Route("PHDs")]
        public async Task<ActionResult> PHDs()
        {
            ViewBag.Title = "PHDs";
            return View();
        }
    }
}
