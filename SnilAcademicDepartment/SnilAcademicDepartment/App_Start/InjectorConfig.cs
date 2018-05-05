using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using SnilAcademicDepartment.Common.Infrastructure;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
// using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.Web;

namespace SnilAcademicDepartment
{
    /// <summary>
    /// Injections initializer (config).
    /// </summary>
    public static class InjectorConfig
    {
        /// <summary>
        /// Injector configurations initialization.
        /// </summary>
        /// <param name="httpConfiguration">
        ///     Instance of type <see cref="HttpConfiguration"/>.
        /// </param>
        /// <returns>
        ///     The container for registration of dependencies.
        /// </returns>
        public static Container Initialize(HttpConfiguration httpConfiguration)
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register types for instance.
            SnilPackage.RegisterSnilTypes(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }
    }
}