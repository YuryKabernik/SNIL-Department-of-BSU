using System;
using System.Web.Mvc;
using NLog;

namespace SnilAcademicDepartment.Filters
{
	/// <summary>
	/// Global exceptionn handler.
	/// </summary>
	/// <seealso cref="System.Web.Mvc.HandleErrorAttribute" />
	public class InternalErrorExceptionHandler : HandleErrorAttribute
	{
		/// <summary>
		/// The logger.
		/// </summary>
		private ILogger logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="InternalErrorExceptionHandler" /> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public InternalErrorExceptionHandler(ILogger logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// Called when an exception occurs.
		/// Processing and logging exception.
		/// </summary>
		/// <param name="filterContext">The action-filter context.</param>
		public override void OnException(ExceptionContext filterContext)
		{
			string messageTemplate =
				$"\n\r\n\r Error occured at {DateTime.UtcNow} UTC from {filterContext.Controller.ToString()}/" +
				$"{filterContext.Exception.TargetSite.Name} with stack trace {filterContext.Exception.StackTrace}\n\r\n\r";

			this.logger.Error(filterContext.Exception, messageTemplate);

			base.OnException(filterContext);
		}
	}
}