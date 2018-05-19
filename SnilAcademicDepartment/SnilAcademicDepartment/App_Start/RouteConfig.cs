using System.Web.Mvc;
using System.Web.Routing;

namespace SnilAcademicDepartment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var lang = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

            routes.MapMvcAttributeRoutes();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "NoIdRoute",
                url: "{language}/{controller}/{action}",
                defaults: new
                {
                    language = lang,
                    controller = "Home",
                    action = "Index"
                }
             );

            routes.MapRoute(
                name: "Default",
                url: "{language}/{controller}/{action}/{id}",
                defaults: new
                {
                    language = lang,
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
             );
        }
    }
}
