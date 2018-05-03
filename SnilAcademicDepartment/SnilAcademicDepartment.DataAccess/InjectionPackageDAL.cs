using SimpleInjector;
using SimpleInjector.Packaging;

namespace SnilAcademicDepartment.DataAccess
{
    class InjectionPackageDAL : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<SnilDBContext,SnilDBContext> (Lifestyle.Scoped);
        }
    }
}
