using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http.Filters;
using NLog;
using SnilAcademicDepartment.Resources.ContactsResources;
using SnilAcademicDepartment.ViewModels;

namespace SnilAcademicDepartment.Filters
{
	public class HttpExceptionHandler : ExceptionFilterAttribute
	{
		/// <summary>
		/// The logger.
		/// </summary>
		private ILogger logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="InternalErrorExceptionHandler" /> class.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public HttpExceptionHandler(ILogger logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// Raises the exception event.
		/// </summary>
		/// <param name="actionExecutedContext">The context for the action.</param>
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			string exceptionMessage = GetExceptionMessage(actionExecutedContext.Exception);

			this.logger.Error(actionExecutedContext.Exception, exceptionMessage);

			actionExecutedContext.Response = this.GenerateErrorResponse();
		}

		/// <summary>
		/// Gets the exception message.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <returns></returns>
		private string GetExceptionMessage(Exception exception)
		{
			return (exception.InnerException == null) ?
				exception.Message : exception.InnerException.Message;
		}

		/// <summary>
		/// Generates the error responce.
		/// </summary>
		/// <returns></returns>
		private HttpResponseMessage GenerateErrorResponse()
		{
			return new HttpResponseMessage(HttpStatusCode.BadRequest)
			{
				Content = new StringContent(Json.Encode(new MailingResult
				{
					ResultCode = (int)HttpStatusCode.BadRequest,
					ResultMessage = ContactsResource.MessageSentFailed + ContactsResource.VictorSkakunMail
				})),
				ReasonPhrase = $"Internal Server Error. Please Contact {ContactsResource.VictorSkakunMail}."
			};
		}
	}
}
