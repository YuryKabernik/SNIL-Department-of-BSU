using System.Net.Mail;
using SimpleInjector;
using SimpleInjector.Packaging;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.BusinessLogic.Managers;
using SnilAcademicDepartment.BusinessLogic.Services;
using SnilAcademicDepartment.Common.ConfigManagerAdapter;
using SnilAcademicDepartment.MailService;

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
            container.Register<IPeople, PeopleService>(Lifestyle.Scoped);
            container.Register<IProjects, ProjectsService>(Lifestyle.Scoped);
            container.Register<IProjectsPreview, ProjectsService>(Lifestyle.Scoped);
            container.Register<ISendMail, SendMailService>(Lifestyle.Scoped);
            container.Register<IService, PreViewService>(Lifestyle.Scoped);
            container.Register<ImageManager>(Lifestyle.Scoped);
            container.Register<ILecturePreview, PreViewService>(Lifestyle.Scoped);
            container.Register<ISeminarPreview, PreViewService>(Lifestyle.Scoped);
            container.Register<IDataBaseFileManager, FileManager>(Lifestyle.Scoped);
			container.Register(() => new SMTPService(container.GetInstance<ISNILConfigurationManager>()), Lifestyle.Scoped);
			container.Register(() => new SmtpClient(), Lifestyle.Singleton);
		}
    }
}
