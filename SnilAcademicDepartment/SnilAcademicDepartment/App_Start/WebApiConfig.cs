using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using NLog;
using SimpleInjector;
using SnilAcademicDepartment.Filters;
using SnilAcademicDepartment.Http;

namespace SnilAcademicDepartment.App_Start
{
	/// <summary>
	/// Api pipeline configuration.
	/// </summary>
	public static class WebApiConfig
	{
		/// <summary>
		/// Registers the specified configuration.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="container">The container.</param>
		public static void Register(HttpConfiguration config, Container container)
		{
			//config.Filters.Add(new HttpExceptionFilter(container.GetInstance<ILogger>()));

			config.Services.Replace(typeof(IExceptionHandler), new GlobalHttpExceptionHandler(container.GetInstance<ILogger>()));

			config.MapHttpAttributeRoutes();
			RegisterRouting(config.Routes);
		}

		/// <summary>
		/// Registers the routing.
		/// </summary>
		/// <param name="httpRoutes">The HTTP routes.</param>
		private static void RegisterRouting(HttpRouteCollection httpRoutes)
		{
			var lang = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

			// Convention-based routing.
			httpRoutes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{language}/{controller}/{action}",
				defaults: new
				{
					language = lang
				}
			);
		}
	}
}
