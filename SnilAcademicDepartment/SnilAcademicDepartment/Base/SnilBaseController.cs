using System;
using System.Web.Mvc;
using NLog;

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

			_logger.Error(exception, $"\n\r\n\rError handled into Application_Error handler and logged on the system.\n\r\n\r" +
				$"Message : {exception.Message}.\n\r\n\r Stack Trace : {exception.StackTrace}\n\r\n\r");

			filterContext.Result = new ViewResult
			{
				ViewName = "Error"
			};
		}
	}
}