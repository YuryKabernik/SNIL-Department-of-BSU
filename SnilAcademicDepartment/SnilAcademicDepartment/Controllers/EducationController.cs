using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;
using SnilAcademicDepartment.BusinessLogic.Models;
using System.Threading;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class EducationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;

        /// <summary>
        /// Constructor of the EducationController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        public EducationController(ILogger logger, IService previewService)
        {
            this._logger = logger;
            this._previewService = previewService;
        }

        [HttpGet]
        [Route("Education")]
        public ActionResult Education()
        {
            PreView viewModel = null;

            try
            {
                // Get data.
                viewModel = this._previewService.GetPagePreview("Education", Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (System.Exception ex)
            {

                throw;
            }

            ViewBag.Title = "Education";
            ViewBag.viewModel = viewModel;

            return View();
        }

        [HttpGet]
        [Route("PageQuickLearning")]
        public ActionResult PageQuickLearning()
        {
            ViewBag.Title = "Quick Learning";
            return View();
        }

        [HttpGet]
        [Route("PageSeminars")]
        public ActionResult PageSeminars()
        {
            ViewBag.Title = "Seminars";
            return View();
        }

        [HttpGet]
        [Route("PageLectures")]
        public ActionResult PageLectures()
        {
            ViewBag.Title = "Lecturs";
            return View();
        }
    }
}