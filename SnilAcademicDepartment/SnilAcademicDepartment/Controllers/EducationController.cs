using System;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;
using System.Threading;
using System.Collections.Generic;
using Resources.EducationResources;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

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
            PreViewModel viewModel = null;
            List<PreViewModel> lecturePreviewsModels = null;

            try
            {
                // viewModel = this._educationService.
            }
            catch (Exception ex)
            {

                throw;
            }

            ViewBag.Title = "Quick Learning";
            ViewBag.EducationResourseTitle = EducationResource.QuickLearning;

            return View("EducationPage");
        }

        [HttpGet]
        [Route("Seminars")]
        public ActionResult PageSeminars()
        {
            ViewBag.Title = "Seminars";
            ViewBag.EducationResourseTitle = EducationResource.Seminars;

            return View("EducationPage");
        }

        [HttpGet]
        [Route("Lectures")]
        public ActionResult PageLectures()
        {
            ViewBag.Title = "Lecturs";
            ViewBag.EducationResourseTitle = EducationResource.Lectures;

            return View("EducationPage");
        }
    }
}