using System;
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
using System.Collections.Specialized;
using SnilAcademicDepartment.Resources.ContactsResources;

namespace SnilAcademicDepartment.Filters
{
	public class ValidateHttpAntiForgeryToken : FilterAttribute, IActionFilter
	{
		private const string XsrfHeader = "XSRF-TOKEN";
		private const string XsrfCookie = "xsrf-token";

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
					throw new HttpResponseException(httpErrorResponseMessage);
				}
				return continuation();
			}
			throw new HttpResponseException(httpErrorResponseMessage);
		}
	}
}