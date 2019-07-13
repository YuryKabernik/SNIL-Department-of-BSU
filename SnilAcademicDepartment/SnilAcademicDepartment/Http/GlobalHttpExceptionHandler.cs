using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using NLog;
using SnilAcademicDepartment.Resources.ContactsResources;

namespace SnilAcademicDepartment.Http
{
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="System.Web.Http.ExceptionHandling.ExceptionHandler" />
	public class GlobalHttpExceptionHandler : ExceptionHandler
	{
		/// <summary>
		/// The logger.
		/// </summary>
		private ILogger logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="GlobalHttpExceptionHandler"/> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public GlobalHttpExceptionHandler(ILogger logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// When overridden in a derived class, handles the exception asynchronously.
		/// </summary>
		/// <param name="context">The exception handler context.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
		/// <returns>
		/// A task representing the asynchronous exception handling operation.
		/// </returns>
		public async override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
		{
			this.LogError(context.Exception, context.ExceptionContext);

			string errorMessage = "An unexpected error occured";
			HttpResponseMessage response = GenerateResponseMessage(context, errorMessage);

			context.Result = new ResponseMessageResult(response);
		}

		/// <summary>
		/// Logs the error.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="exceptionContext">The exception context.</param>
		/// <exception cref="NotImplementedException"></exception>
		private void LogError(Exception exception, ExceptionContext exceptionContext)
		{
			string message = $"Error occured at {DateTime.UtcNow} (UTC) in {exceptionContext.Exception.StackTrace}";

			this.logger.Error($"\n\r ----------------- {message} ----------------- \n\r");
			this.logger.Error(exception, $"Error occured at {DateTime.UtcNow} (UTC)");
		}

		/// <summary>
		/// Generates the response message.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="errorMessage">The error message.</param>
		/// <returns></returns>
		private static HttpResponseMessage GenerateResponseMessage(ExceptionHandlerContext context, string errorMessage)
		{
			HttpResponseMessage response = context.Request
				.CreateResponse(
					HttpStatusCode.InternalServerError,
					new
					{
						ResultCode = (int)HttpStatusCode.InternalServerError,
						ResultMessage = ContactsResource.MessageSentFailed + ContactsResource.VictorSkakunMail
					}
			);
			response.Headers.Add("X-Error", errorMessage);
			return response;
		}
	}
}