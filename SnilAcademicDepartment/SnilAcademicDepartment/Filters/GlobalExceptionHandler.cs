using System.Web.Mvc;
using NLog;

namespace SnilAcademicDepartment.Filters
{
	/// <summary>
	/// Global exceptionn handler.
	/// </summary>
	/// <seealso cref="System.Web.Mvc.HandleErrorAttribute" />
	public class GlobalExceptionHandler : HandleErrorAttribute
	{
		private ILogger logger;

		public GlobalExceptionHandler(ILogger logger)
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
			base.OnException(filterContext);
		}
	}
}