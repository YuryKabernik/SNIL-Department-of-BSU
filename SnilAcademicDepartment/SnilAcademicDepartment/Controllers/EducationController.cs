using System;
using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;
using System.Threading;
using System.Collections.Generic;
using Resources.EducationResources;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Linq;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class EducationController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;
        private readonly IEducation _educationService;
        private readonly ILecturePreview _lecturePreviewService;
        private readonly ISeminarPreview _seminarPreviewService;

        /// <summary>
        /// Constructor of the EducationController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        /// <param name="educationService"></param>
        /// <param name="lecturePreviewService"></param>
        /// <param name="seminarPreviewService"></param>
        public EducationController(
            ILogger logger,
            IService previewService, 
            IEducation educationService, 
            ILecturePreview lecturePreviewService,
            ISeminarPreview seminarPreviewService)
        {
            this._logger = logger;
            this._previewService = previewService;
            this._educationService = educationService;
            this._lecturePreviewService = lecturePreviewService;
            this._seminarPreviewService = seminarPreviewService;
        }

        [HttpGet]
        [Route("Education")]
        public async Task<ActionResult> Education()
        {
            PreViewModel viewModel = null;
            List<EducationBlockModel> blockCollection = null;

            try
            {
                // Get page preview data.
                viewModel = await this._previewService.GetPagePreviewAsync("Education", Thread.CurrentThread.CurrentCulture.LCID);

                // Get educatio key areas.
                blockCollection = await this._educationService.GetKeyAreasAsync(20, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Sorry, but education page is not avaliable now :( \n Try again later!";
                return View("Error");
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
                viewModel = this._educationService.GetEducationBlockById(3, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception)
            {
            
                ViewBag.ErrorMessage = "Sorry, but education page is not avaliable now :( \n Try again later!";
                return View("Error");
            }

            ViewBag.Title = "Quick Learning";
            ViewBag.EducationResourseTitle = EducationResource.QuickLearning;
            ViewBag.Components = viewModel;

            return View("EducationBlockPage");
        }

        [HttpGet]
        [Route("Seminars")]
        public async Task<ActionResult> PageSeminars()
        {
            IEnumerable<IGrouping<int, SeminarPreview>> seninarsPreviewsModels = null;

            try
            {
                seninarsPreviewsModels = await this._seminarPreviewService.GetSeminarPreviewsAsync<SeminarPreview>(20, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {

                return Redirect(Request.UrlReferrer.AbsoluteUri ?? "/");
            }

            ViewBag.Title = "Seminars";
            ViewBag.EducationResourseTitle = EducationResource.Seminars;
            ViewBag.Components = seninarsPreviewsModels;

            return View("EducationBlockPage");
        }

        [HttpGet]
        [Route("Lections")]
        public async Task<ActionResult> PageLectures()
        {
            IEnumerable<LecturePreview> lecturePreviewsModels = null;

            try
            {
                lecturePreviewsModels = await this._lecturePreviewService.GetLecturePreviewsAsync<LecturePreview>(20, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {

                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Title = "Lections";
            ViewBag.EducationResourseTitle = EducationResource.Lectures;
            ViewBag.Components = lecturePreviewsModels;

            return View("EducationBlockPage");
        }
    }
}