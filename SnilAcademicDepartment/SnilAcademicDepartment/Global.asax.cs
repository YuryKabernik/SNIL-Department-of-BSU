using System;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using SimpleInjector;
using SnilAcademicDepartment.App_Start;

namespace SnilAcademicDepartment
{
	public class MvcApplication : System.Web.HttpApplication
	{
		/// <summary>
		/// The container.
		/// </summary>
		private Container _container;

		/// <summary>
		/// The logger.
		/// </summary>
		private Lazy<ILogger> logger;

		public MvcApplication()
		{
			logger = new Lazy<ILogger>(
				() => this._container.GetInstance<ILogger>(),
				LazyThreadSafetyMode.ExecutionAndPublication
			);
		}

		/// <summary>
		/// Applications the start.
		/// </summary>
		protected void Application_Start()
		{
			// Initializes Injector configs.
			this._container = InjectorConfig.Initialize(GlobalConfiguration.Configuration);

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(
				(httpConfiguraton) => WebApiConfig.Register(httpConfiguraton, this._container)
			);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, this._container);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		/// <summary>
		/// Applications the error.
		/// </summary>
		protected void Application_Error()
		{
			Exception exception = Server.GetLastError();
			this.logger.Value.Error(exception, $"\n\r\n\rError handled into Application_Error handler and logged on the system.\n\r\n\r" +
				$"Message : {exception.Message}.\n\r\n\r Stack Trace : {exception.StackTrace}\n\r\n\r");
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
