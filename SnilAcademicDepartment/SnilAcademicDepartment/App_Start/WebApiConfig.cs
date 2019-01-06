using System.Web.Http;

namespace SnilAcademicDepartment.App_Start
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var lang = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
			
			// Attribute routing.
			config.MapHttpAttributeRoutes();

			// Convention-based routing.
			config.Routes.MapHttpRoute(
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