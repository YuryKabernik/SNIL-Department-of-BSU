using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NLog;
using SnilAcademicDepartment.Resources.ContactsResources;

namespace SnilAcademicDepartment.Filters
{
	public class ValidateHttpAntiForgeryToken : FilterAttribute, IActionFilter
	{
		private const string XsrfHeader = "XSRF-TOKEN";
		private const string XsrfCookie = "xsrf-token";
		private readonly ILogger _logger;

		public ValidateHttpAntiForgeryToken(ILogger logger)
		{
			this._logger = logger;
		}

		public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
		{
			CookieHeaderValue cookie = actionContext.Request.Headers
				.GetCookies(AntiForgeryConfig.CookieName)
				.FirstOrDefault();

			var message = ContactsResource.MessageSentFailed + ContactsResource.VictorSkakunMail;
			var httpErrorResponseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = message };

			if (cookie != null)
			{
				Stream requestBufferedStream = actionContext.Request.Content.ReadAsStreamAsync().Result;
				requestBufferedStream.Position = 0;
				NameValueCollection myform = actionContext.Request.RequestUri.ParseQueryString();
				try
				{
					AntiForgery.Validate(cookie[AntiForgeryConfig.CookieName].Value,
					 myform["tn"]);
				}
				catch (Exception ex)
				{
					this._logger.Error(ex, $"Error occured in {ex.Source}. Stack trace: {ex.StackTrace}");
					throw new HttpResponseException(httpErrorResponseMessage);
				}
				return continuation();
			}

			this._logger.Warn($"Unauthorized User has tried to send message, but the cookie header '{AntiForgeryConfig.CookieName}' didn't found.");

			throw new HttpResponseException(httpErrorResponseMessage);
		}
	}
}