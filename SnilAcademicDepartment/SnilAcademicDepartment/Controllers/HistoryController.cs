using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
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
        public async Task<ActionResult> History()
        {
            ViewBag.Title = "History";
            return View();
        }

        [HttpGet]
        [Route("PageArchive")]
        public async Task<ActionResult> PageArchive()
        {
            ViewBag.Title = "Archive";
            return View();
        }

        [HttpGet]
        [Route("PageIEEE")]
        public async Task<ActionResult> PageIEEE()
        {
            ViewBag.Title = "IEEE";
            return View();
        }

        [HttpGet]
        [Route("PageReview")]
        public async Task<ActionResult> PageReview()
        {
            ViewBag.Title = "Review";
            return View();
        }

        [HttpGet]
        [Route("PageReports")]
        public async Task<ActionResult> PageReports()
        {
            ViewBag.Title = "Reports";
            return View();
        }
    }
}