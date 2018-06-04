using System;
using System.Threading.Tasks;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.Controllers
{
    //[Culture]
    [RoutePrefix("{language}")]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;
        private readonly ISendMail _mailSender;

        /// <summary>
        /// Constructor of the HomeController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        /// <param name="mailSender">Service for sending mail.</param>
        public HomeController(ILogger logger, IService previewService, ISendMail mailSender)
        {
            this._logger = logger;
            this._previewService = previewService;
            _mailSender = mailSender;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        [Route("Sendrequest")]
        public ActionResult SendMailMessage(ClientMail mail)
        {
            try
            {
                this._mailSender.SendMailToAdmin(mail);
            }
            catch (Exception e)
            {
                
                throw;
            }
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
    }
}