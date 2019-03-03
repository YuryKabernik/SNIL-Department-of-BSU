using System;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
	public class Pedagogue
	{
		public int Id { get; set; }

		public string PersonName { get; set; }

		public string SecoundName { get; set; }

		public string FathersName { get; set; }

		public string ProfessionStatus { get; set; }

		public string Degree { get; set; }

		public string AcademicTitle { get; set; }

		public string EmailAddress { get; set; }

		public string PhoneNumber { get; set; }

		public string PersonalInterests { get; set; }

		public int ImageId { get; set; }

		public DateTime DateRelease { get; set; }

		public DateTime DataAssign { get; set; }
	}
}
