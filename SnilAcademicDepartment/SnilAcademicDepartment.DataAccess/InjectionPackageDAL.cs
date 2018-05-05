using SimpleInjector;
using SimpleInjector.Packaging;

namespace SnilAcademicDepartment.DataAccess
{
    public class InjectionPackageDAL : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<SnilDBContext>(Lifestyle.Scoped);
        }
    }
}
