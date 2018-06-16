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
        public Task<ActionResult> History()
        {
            ViewBag.Title = "History";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("PageArchive")]
        public Task<ActionResult> PageArchive()
        {
            ViewBag.Title = "Archive";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("PageIEEE")]
        public Task<ActionResult> PageIEEE()
        {
            ViewBag.Title = "IEEE";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("PageReview")]
        public Task<ActionResult> PageReview()
        {
            ViewBag.Title = "Review";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("PageReports")]
        public Task<ActionResult> PageReports()
        {
            ViewBag.Title = "Reports";
            return Task.FromResult<ActionResult>(View());
        }
    }
}