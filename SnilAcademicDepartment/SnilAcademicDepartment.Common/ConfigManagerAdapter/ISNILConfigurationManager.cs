using System.Configuration;
using System;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.Common.ConfigManagerAdapter
{
	/// <summary>
	/// 
	/// </summary>
	public interface ISNILConfigurationManager
	{
		/// <summary>
		/// Gets the configuration <see cref="Int32"/> value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// <see cref="Int32"/> value of configuration section.
		/// </returns>
		/// <exception cref="ArgumentException"> Null, empty or whitespace of string key parameter.</exception>
		/// <exception cref="ConfigurationErrorsException">Key doesn't exists in configuration section.</exception>
		Task<int> GetConfigValueIntAsync(string key);

		/// <summary>
		/// Gets the configuration <see cref="string"/> value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// <see cref="string" /> value of configuration section.
		/// </returns>
		/// <exception cref="ArgumentException"> Null, empty or whitespace of string key parameter.</exception>
		/// <exception cref="ConfigurationErrorsException">Key doesn't exists in configuration section.</exception>
		Task<string> GetConfigValueStringAsync(string key);
	}
}