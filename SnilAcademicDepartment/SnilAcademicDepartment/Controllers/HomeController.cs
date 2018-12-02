using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;
using Resources;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.Controllers
{
    //[Culture]
    [RoutePrefix("{language}")]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;

        /// <summary>
        /// Constructor of the HomeController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        /// <param name="mailSender">Service for sending mail.</param>
        public HomeController(ILogger logger, IService previewService)
        {
            this._logger = logger;
            this._previewService = previewService;
        }

        [HttpGet]
        public Task<ActionResult> Index()
        {
			ViewBag.Title = Resource.IndexHeader;
			return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("About")]
        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public async Task<ActionResult> Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}