using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;
using System.Threading;
using System.Collections.Generic;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System;
using System.Web.Helpers;
using System.Text;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class EducationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;
        private readonly IEducation _educationService;

        /// <summary>
        /// Constructor of the EducationController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        public EducationController(ILogger logger, IService previewService, IEducation educationService)
        {
            this._logger = logger;
            this._previewService = previewService;
            this._educationService = educationService;
        }

        [HttpGet]
        [Route("Education")]
        public ActionResult Education()
        {
            PreViewModel viewModel = null;
            List<EducationBlockModel> blockCollection = null;

            try
            {
                // Get page preview data.
                viewModel = this._previewService.GetPagePreview("Education", Thread.CurrentThread.CurrentCulture.LCID);

                // Get educatio key areas.
                blockCollection = this._educationService.GetKeyAreas(5, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (System.Exception ex)
            {
                throw;
            }

            ViewBag.Title = "Education";
            ViewBag.viewModel = viewModel;
            ViewBag.blockModel = blockCollection;

            return View();
        }

        [HttpGet]
        [Route("QuickLearning")]
        public ActionResult PageQuickLearning()
        {
            ViewBag.Title = "Quick Learning";
            return View();
        }

        [HttpGet]
        [Route("Seminars")]
        public ActionResult PageSeminars()
        {
            ViewBag.Title = "Seminars";
            return View();
        }

        [HttpGet]
        [Route("Lectures")]
        public ActionResult PageLectures()
        {
            ViewBag.Title = "Lecturs";
            return View();
        }

        //[HttpGet]
        //[Route("image")]
        //public void GetImage(string id)
        //{
        //    byte[] bytes = Encoding.ASCII.GetBytes(id);
        //    var res = new FileContentResult(bytes,"image/jpeg");
        //    res.ExecuteResult(this.ControllerContext);
        //}
    }
}