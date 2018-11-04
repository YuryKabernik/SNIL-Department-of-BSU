using System.Configuration;
using System;

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
		int GetConfigValueInt(string key);

		/// <summary>
		/// Gets the configuration <see cref="string"/> value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// <see cref="string" /> value of configuration section.
		/// </returns>
		/// <exception cref="ArgumentException"> Null, empty or whitespace of string key parameter.</exception>
		/// <exception cref="ConfigurationErrorsException">Key doesn't exists in configuration section.</exception>
		string GetConfigValueString(string key);
	}
}