using System.Configuration;
using System.Collections.Specialized;

namespace SnilAcademicDepartment.Common.ConfigManagerAdapter
{
	/// <summary>
	/// Adapter to connect configuration manager to controllers.
	/// </summary>
	/// <seealso cref="SnilAcademicDepartment.Common.ConfigManagerAdapter.ISNILConfigurationManager" />
	public class SNILConfigurationManager : ISNILConfigurationManager
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SNILConfigurationManager"/> class.
		/// </summary>
		public SNILConfigurationManager()
		{
			this.ConfigurationFile = ConfigurationManager.AppSettings;
		}

		/// <summary>
		/// Gets the configuration file.
		/// </summary>
		/// <value>
		/// The configuration file.
		/// </value>
		public NameValueCollection ConfigurationFile { get; }
	}
}
