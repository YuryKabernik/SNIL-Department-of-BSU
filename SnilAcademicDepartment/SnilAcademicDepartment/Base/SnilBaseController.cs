using System;
using System.Web.Mvc;
using NLog;
using Resources;
using SnilAcademicDepartment.Resources.ContactsResources;
using SnilAcademicDepartment.Resources.UnavaliableErrorResources;

namespace SnilAcademicDepartment.Base
{
	/// <summary>
	/// Base class for all controllers.
	/// </summary>
	/// <seealso cref="System.Web.Mvc.Controller" />
	public abstract class SnilBaseController : Controller
	{
		/// <summary>
		/// The logger.
		/// </summary>
		protected readonly ILogger _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="SnilBaseController"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public SnilBaseController(ILogger logger)
		{
			this._logger = logger;
		}

		/// <summary>
		/// Called when an unhandled exception occurs in the action.
		/// </summary>
		/// <param name="filterContext">Information about the current request and action.</param>
		protected override void OnException(ExceptionContext filterContext)
		{
			if (!filterContext.ExceptionHandled)
			{
				filterContext.ExceptionHandled = true;
			}

			Exception exception = filterContext.Exception;

			_logger.Error(exception, $"\n\r\n\rError has been handled in OnException handler of {this} and logged on the system.\n\r\n\r" +
				$"Message : {exception.Message}.\n\r\n\r Stack Trace : {exception.StackTrace}\n\r\n\r");

			ViewResult unavailableViewResult = new ViewResult
			{
				ViewName = "~/Views/Error/SorryUnavaliable.cshtml"
			};
			unavailableViewResult.ViewBag.Title = Resource.Error;
			unavailableViewResult.ViewData["ErrorMessage"] = $"{UnavaliableErrorResource.UnavaliableMessage} {UnavaliableErrorResource.ContactWithLabel} {ContactsResource.VictorSkakunMail}";

			filterContext.Result = unavailableViewResult;
		}
	}
}