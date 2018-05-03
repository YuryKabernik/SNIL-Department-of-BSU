using NLog;
using SimpleInjector;
using SimpleInjector.Packaging;
using SnilAcademicDepartment.Common.LoggerAdapter;

namespace SnilAcademicDepartment.Common
{
    /// <summary>
    /// Registering services in SimpleInjector in runtime.
    /// Uses contract <see cref="IPackage"/> for allow registering a set of services.
    /// </summary>
    public class CommonPackage : IPackage
    {
        /// <summary>
        /// Registers injections in WebApi layer with a help of <see cref="SimpleInjector.Packaging"/>.
        /// Registers types for instances using the <see cref="Lifestyle.Scoped"/> or
        /// <see cref="Lifestyle.Singleton"/> or /<see cref="Lifestyle.Transient"/> lifestyle.
        /// </summary>
        /// <param name="container">Container of types and instances.</param>
        public void RegisterServices(Container container)
        {
            // Logger singleton for each one request.
            container.RegisterConditional(
                typeof(ILogger),
                context => typeof(NLogAdapter<>).MakeGenericType(context.Consumer.ImplementationType),
                Lifestyle.Singleton,
                context => true);
        }
    }
}
