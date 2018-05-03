using SimpleInjector;
using SimpleInjector.Packaging;
using System;
using System.Data.Entity;

namespace SnilAcademicDepartment.DataAccess
{
    class InjectionPackageDAL : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<SnilDBContext> (Lifestyle.Scoped);
        }
    }
}
