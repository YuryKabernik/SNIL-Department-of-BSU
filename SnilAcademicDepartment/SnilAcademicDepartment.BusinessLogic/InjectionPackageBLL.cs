using SimpleInjector;
using SimpleInjector.Packaging;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Services;

namespace SnilAcademicDepartment.BusinessLogic
{
    public class InjectionPackageBLL : IPackage
    {
        public void RegisterServices(Container container)
        {
            // Register Services.
            container.Register<ICookieManager, CookieManager>(Lifestyle.Scoped);
            container.Register<IEducation, EducationService>(Lifestyle.Scoped);
            container.Register<IHistory, HistoryService>(Lifestyle.Scoped);
            container.Register<IIndex, HomeService>(Lifestyle.Scoped);
            container.Register<IMailSender, SendMailService>(Lifestyle.Scoped);
            container.Register<IPeople, PeopleService>(Lifestyle.Scoped);
            container.Register<IProjects, ProjectsService>(Lifestyle.Scoped);
            container.Register<IProjectsPreview, ProjectsService>(Lifestyle.Scoped);
            container.Register<ISendMail, SendMailService>(Lifestyle.Scoped);
            container.Register<IService, PreViewService>(Lifestyle.Scoped);
        }
    }
}
