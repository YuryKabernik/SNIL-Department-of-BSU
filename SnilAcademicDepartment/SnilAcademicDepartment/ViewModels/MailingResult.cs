using Newtonsoft.Json;

namespace SnilAcademicDepartment.ViewModels
{
	[JsonObject]
	public class MailingResult
	{
		/// <summary>
		/// Gets or sets the result code.
		/// </summary>
		/// <value>
		/// The result code.
		/// </value>
		public int ResultCode { get; set; }
		/// <summary>
		/// Gets or sets the result message.
		/// </summary>
		/// <value>
		/// The result message.
		/// </value>
		public string ResultMessage { get; set; }
	}
}