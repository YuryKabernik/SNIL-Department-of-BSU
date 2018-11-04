using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using System;

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
			this._configurationFile = ConfigurationManager.AppSettings;
		}

		/// <summary>
		/// Gets the configuration file.
		/// </summary>
		/// <value>
		/// The configuration file.
		/// </value>
		private NameValueCollection _configurationFile;

		/// <summary>
		/// Gets the configuration <see cref="Int32"/> value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// <see cref="Int32"/> value of configuration section.
		/// </returns>
		/// <exception cref="ArgumentException"> Null, empty or whitespace of string key parameter.</exception>
		/// <exception cref="ConfigurationErrorsException">Key doesn't exists in configuration section.</exception>
		public int GetConfigValueInt(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				throw new ArgumentException($"Value of argument '{nameof(key)}' is null empty or whitespace.");
			}

			if (this._configurationFile.AllKeys.Contains(key))
			{
				var value = this._configurationFile[key];
				var result = Convert.ToInt32(value);

				return result;
			}

			throw new ConfigurationErrorsException($"Key '{key}' doesn't exists in configuration section.");
		}

		/// <summary>
		/// Gets the configuration <see cref="string"/> value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// <see cref="string" /> value of configuration section.
		/// </returns>
		/// <exception cref="ArgumentException"> Null, empty or whitespace of string key parameter.</exception>
		/// <exception cref="ConfigurationErrorsException">Key doesn't exists in configuration section.</exception>
		public string GetConfigValueString(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
			{
				throw new ArgumentException($"Value of argument '{nameof(key)}' is null empty or whitespace.");
			}

			if (this._configurationFile.AllKeys.Contains(key))
			{
				var value = this._configurationFile[key];

				return value;
			}

			throw new ConfigurationErrorsException($"Key '{key}' doesn't exists in configuration section.");
		}
	}
}
