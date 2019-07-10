using System.Threading.Tasks;
using System.Web.Mvc;
using NLog;
using Resources;
using SnilAcademicDepartment.Base;
using SnilAcademicDepartment.BusinessLogic.Interfaces;

namespace SnilAcademicDepartment.Controllers
{
	//[Culture]
	[RoutePrefix("{language}")]
    public class HomeController : SnilBaseController
	{
        private readonly IService _previewService;

        /// <summary>
        /// Constructor of the HomeController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        /// <param name="mailSender">Service for sending mail.</param>
        public HomeController(ILogger logger, IService previewService) : base(logger)
        {
            this._previewService = previewService;
        }

        [HttpGet]
        public Task<ActionResult> Index()
        {
			ViewBag.Title = Resource.IndexHeader;
			return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("about")]
        public Task<ActionResult> About()
        {
            ViewBag.Message = Resource.About;
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("contacts")]
        public Task<ActionResult> Contact()
        {
            ViewBag.Message = Resource.ContactsPage;
            return Task.FromResult<ActionResult>(View());
        }

        [HttpGet]
        [Route("collaboration")]
        public Task<ActionResult> Collaboration()
        {
            ViewBag.Message = Resource.Collaboration;
            return Task.FromResult<ActionResult>(View());
        }
    }
}