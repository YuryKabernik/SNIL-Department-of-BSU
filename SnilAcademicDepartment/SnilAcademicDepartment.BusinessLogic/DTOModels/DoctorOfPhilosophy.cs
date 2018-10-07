using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
	public class DoctorOfPhilosophy
	{
		public int Id { get; set; }

		public string PersonName { get; set; }

		public string SecoundName { get; set; }

		public string FathersName { get; set; }

		public string ProfessionStatus { get; set; }

		public string Degree { get; set; }

		public string AcademicTitle { get; set; }

		public string PersonalInterests { get; set; }

		public byte[] Image { get; set; }

		public string Biography { get; set; }

		/// <summary>
		/// Professor's email address.
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// Professor's phone number.
		/// </summary>
		public string PhoneNumber { get; set; }

		public IEnumerable<string> Projects { get; set; }

		public IEnumerable<string> Seminars { get; set; }
	}
}
