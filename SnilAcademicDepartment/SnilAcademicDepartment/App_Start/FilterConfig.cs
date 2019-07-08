using System.Web.Mvc;
using NLog;
using SimpleInjector;
using SnilAcademicDepartment.Filters;

namespace SnilAcademicDepartment
{
	public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
		{
			filters.Add(new GlobalExceptionHandler(container.GetInstance<ILogger>()));
			filters.Add(new CultureAttribute());
		}
    }
}
