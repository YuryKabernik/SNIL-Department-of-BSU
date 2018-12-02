using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SnilAcademicDepartment.Filters
{
	public class HttpCultureAttribute : FilterAttribute, IActionFilter
	{
		/// <summary>
		/// Culture filter on action executed.
		/// </summary>
		/// <param name="filterContext"> Action executed context.</param>
		public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
		{
			string cultureName = string.Empty;

			try
			{
				// Get language from route.
				cultureName = this.GetRouteCulture(actionContext);

				// Get language from cookies.
				if (string.IsNullOrEmpty(cultureName))
					cultureName = this.GetCookieCulture(actionContext);

				// Get language from request headers.
				if (string.IsNullOrEmpty(cultureName))
					cultureName = this.GetHeaderCulture(actionContext);
			}
			catch (CultureNotFoundException)
			{
				cultureName = "ru-RU";
			}

			if (string.IsNullOrEmpty(cultureName))
				cultureName = "ru-RU";

			// Set culture if it's not user custom culture.
			this.SetThreadCulture(cultureName);
			return continuation();
		}

		/// <summary>
		/// Method of finding culture in cookies.
		/// </summary>
		/// <param name="filterContext">Base filter context.</param>
		/// <returns>The string of current request culture.</returns>
		private string GetCookieCulture(HttpActionContext filterContext)
		{
			// Получаем куки из контекста, которые могут содержать установленную культуру
			var cultureCookie = filterContext.Request.Headers.GetCookies("language").FirstOrDefault();

			if (cultureCookie != null)
				return CultureInfo.GetCultureInfo(cultureCookie["language"].Value).TextInfo.CultureName;
			else
				return null;
		}

		/// <summary>
		/// Method of getting culture in route.
		/// </summary>
		/// <param name="filterContext">Base filter context.</param>
		/// <returns>The string of current request culture.</returns>
		private string GetRouteCulture(HttpActionContext filterContext)
		{
			var routeLanguage = filterContext.Request.GetRouteData().Values["language"] as string;

			if (!string.IsNullOrEmpty(routeLanguage))
				return CultureInfo.GetCultureInfo(routeLanguage).TextInfo.CultureName;

			return null;
		}

		/// <summary>
		/// Method of finding a culture in request headers.
		/// </summary>
		/// <param name="filterContext">Base filter context.</param>
		/// <returns>The string of current request culture.</returns>
		private string GetHeaderCulture(HttpActionContext filterContext)
		{
			// Получаем заголовок из запроса, который может содержать установленную культуру
			var userLanguages = filterContext.Request.Headers.AcceptLanguage.ToArray();

			if (userLanguages != null && userLanguages.Length != 0)
				return CultureInfo.GetCultureInfo(userLanguages[0].Value).TextInfo.CultureName;

			return null;
		}

		/// <summary>
		/// Sets user's culture or default culture to thread.
		/// </summary>
		/// <param name="cultureName">Culture to set in current Thread.</param>
		private void SetThreadCulture(string cultureName)
		{
			var isCustomCulture = new CultureInfo(cultureName).CultureTypes.HasFlag(CultureTypes.UserCustomCulture);

			if (!isCustomCulture)
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
				Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
			}
			else
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ru-RU");
				Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ru-RU");
			}
		}
	}
}