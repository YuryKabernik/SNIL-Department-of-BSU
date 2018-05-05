using NLog;
using SnilAcademicDepartment.Filters;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
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
        public ActionResult Persons()
        {
            ViewBag.Title = "Persons";
            return View();
        }

        [HttpGet]
        public ActionResult Administration()
        {
            ViewBag.Title = "Administration";
            return View();
        }

        [HttpGet]
        public ActionResult Students()
        {
            ViewBag.Title = "Stuedents";
            return View();
        }

        [HttpGet]
        public ActionResult MS()
        {
            ViewBag.Title = "MS";
            return View();
        }

        [HttpGet]
        public ActionResult PHDs()
        {
            ViewBag.Title = "PHDs";
            return View();
        }
    }
}
