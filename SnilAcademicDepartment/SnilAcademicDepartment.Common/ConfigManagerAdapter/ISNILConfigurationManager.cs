using System.Collections.Specialized;

namespace SnilAcademicDepartment.Common.ConfigManagerAdapter
{
	public interface ISNILConfigurationManager
	{
		NameValueCollection ConfigurationFile { get; }
	}
}