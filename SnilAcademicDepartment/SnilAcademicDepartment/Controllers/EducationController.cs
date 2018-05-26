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
        private readonly ILecturePreview _lecturePreview;
        private readonly ISeminarPreview _seminarPreview;

        /// <summary>
        /// Constructor of the EducationController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        public EducationController(
            ILogger logger,
            IService previewService, 
            IEducation educationService, 
            ILecturePreview lecturePreview,
            ISeminarPreview seminarPreview)
        {
            this._logger = logger;
            this._previewService = previewService;
            this._educationService = educationService;
            this._lecturePreview = lecturePreview;
            this._seminarPreview = seminarPreview;
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

            int i = 1;
            foreach (var item in blockCollection)
            {
                item.ActionId = i++;
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
            EducationBlockModel viewModel = null;

            try
            {
                viewModel = this._educationService.GetEducationBlock("QuickLearning", Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception ex)
            {

                throw;
            }

            ViewBag.Title = "Quick Learning";
            ViewBag.EducationResourseTitle = EducationResource.QuickLearning;
            ViewBag.ViewModel = viewModel;

            return View("EducationBlockPage");
        }

        [HttpGet]
        [Route("Seminars")]
        public ActionResult PageSeminars()
        {
            EducationBlockModel viewModel = null;
            IEnumerable<SeminarPreview> seninarsPreviewsModels = null;

            try
            {
                //viewModel = this._educationService.GetEducationBlock("Seminar", Thread.CurrentThread.CurrentCulture.LCID);

                //seninarsPreviewsModels = this._seminarPreview.GetSeminarPreviews<SeminarPreview>(3, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception ex)
            {

                throw;
            }

            ViewBag.Title = "Seminars";
            ViewBag.EducationResourseTitle = EducationResource.Seminars;
            ViewBag.ViewModel = viewModel;
            ViewBag.Components = seninarsPreviewsModels;

            return View("EducationBlockPage");
        }

        [HttpGet]
        [Route("Lections")]
        public ActionResult PageLectures()
        {
            EducationBlockModel viewModel = null;
            IEnumerable<LecturePreview> lecturePreviewsModels = null;

            try
            {
                viewModel = this._educationService.GetEducationBlock("Lection", Thread.CurrentThread.CurrentCulture.LCID);

                lecturePreviewsModels = this._lecturePreview.GetLecturePreviews<LecturePreview>(3, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {

                throw;
            }

            ViewBag.Title = "Lections";
            ViewBag.EducationResourseTitle = EducationResource.Lectures;
            ViewBag.ViewModel = viewModel;
            ViewBag.Components = lecturePreviewsModels;

            return View("EducationBlockPage");
        }
    }
}