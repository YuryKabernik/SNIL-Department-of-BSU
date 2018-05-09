using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
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
        public ActionResult Persons()
        {
            ViewBag.Title = "Persons";
            return View();
        }

        [HttpGet]
        [Route("Administration")]
        public ActionResult Administration()
        {
            ViewBag.Title = "Administration";
            return View();
        }

        [HttpGet]
        [Route("Students")]
        public ActionResult Students()
        {
            ViewBag.Title = "Stuedents";
            return View();
        }

        [HttpGet]
        [Route("MS")]
        public ActionResult MS()
        {
            ViewBag.Title = "Master of Science";
            return View();
        }

        [HttpGet]
        [Route("PHDs")]
        public ActionResult PHDs()
        {
            ViewBag.Title = "PHDs";
            return View();
        }
    }
}
