using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.Filters;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class HistoryController : Controller
    {
        private readonly ILogger _logger;
        private readonly IHistory _historyService;

        /// <summary>
        /// Constructor of the HistoryController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="historyService"></param>
        public HistoryController(ILogger logger, IHistory historyService)
        {
            this._logger = logger;
            this._historyService = historyService;
        }

        [HttpGet]
        [Route("History")]
        public ActionResult History()
        {
            ViewBag.Title = "History";
            return View();
        }

        [HttpGet]
        [Route("PageArchive")]
        public ActionResult PageArchive()
        {
            ViewBag.Title = "Archive";
            return View();
        }

        [HttpGet]
        [Route("PageIEEE")]
        public ActionResult PageIEEE()
        {
            ViewBag.Title = "IEEE";
            return View();
        }

        [HttpGet]
        [Route("PageReview")]
        public ActionResult PageReview()
        {
            ViewBag.Title = "Review";
            return View();
        }

        [HttpGet]
        [Route("PageReports")]
        public ActionResult PageReports()
        {
            ViewBag.Title = "Reports";
            return View();
        }
    }
}