namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
	public class ClientMail
	{
		/// <summary>
		/// Full name of client.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Client's mail.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The company the representative of which the sender is.
		/// </summary>
		public string Company { get; set; }

		/// <summary>
		/// Mail subject.
		/// </summary>
		public string Subject { get; set; }

		/// <summary>
		/// Mail message.
		/// </summary>
		public string Message { get; set; }
	}
}