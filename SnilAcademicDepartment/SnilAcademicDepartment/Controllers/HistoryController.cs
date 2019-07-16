using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using SnilAcademicDepartment.Base;
using SnilAcademicDepartment.BusinessLogic.Interfaces;

namespace SnilAcademicDepartment.Controllers
{
	[RoutePrefix("{language}")]
    public class HistoryController : SnilBaseController
	{
        private readonly IHistory _historyService;

        /// <summary>
        /// Constructor of the HistoryController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="historyService"></param>
        public HistoryController(ILogger logger, IHistory historyService) : base(logger)
        {
            this._historyService = historyService;
        }

        [HttpGet]
        [Route("history")]
        public Task<ActionResult> History()
        {
            ViewBag.Title = "History";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("archive")]
        public Task<ActionResult> PageHistory()
        {
            ViewBag.Title = "History";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("ieee")]
        public Task<ActionResult> PageIEEE()
        {
            ViewBag.Title = "IEEE";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("ITEDS2010")]
        public Task<ActionResult> PageITEDS2010()
        {
            ViewBag.Title = "ITEDS'2010";
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("CTDA2020")]
        public Task<ActionResult> PageCTDA2020()
        {
            ViewBag.Title = "CTDA'2020";
            return Task.FromResult<ActionResult>(View());
        }
    }
}