using SimpleInjector;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SnilAcademicDepartment
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Container _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initializes Injector configs.
            this._container = InjectorConfig.Initialize(GlobalConfiguration.Configuration);
        }

        /// <summary>
        /// <summary>
        /// Added to make sure that instances with singleton lifestyle have been disposed while application ending.
        /// Such disposal requires for <see cref="DbTarget"/> correct work.
        /// </summary>
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        public void Application_End(object sender, EventArgs e)
        {
            this._container.Dispose();
        }
    }
}
