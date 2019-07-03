using System.Collections.Generic;
using SnilAcademicDepartment.DataAccess.Models.Education;

namespace SnilAcademicDepartment.DataAccess.Models
{
	public partial class Person
	{
		public int PersonId { get; set; }

		public int PersonUniqueIdentifire { get; set; }

		public string PersonName { get; set; }

		public string SecoundName { get; set; }

		public string FathersName { get; set; }

		public ProfessionStatus ProfessionStatus { get; set; }

		public Degree Degree { get; set; }

		public AcademicTitle AcademicTitle { get; set; }

		public int? Biography { get; set; }

		public string PersonalInterests { get; set; }

		public string EmailAddress { get; set; }

		public string PhoneNumber { get; set; }

		public Image Image { get; set; }

		public int Localisation { get; set; }

		// Внешние связи
		#region Table Dependencies

		public virtual Biography Biography1 { get; set; }

		public virtual ICollection<HallOfFame> HallOfFames { get; set; } = new HashSet<HallOfFame>();

		public virtual Language Language { get; set; }

		public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

		public virtual ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();

		public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();

		public virtual ICollection<Diploma> Diplomas { get; set; } = new HashSet<Diploma>();

		public virtual ICollection<StuffPersonal> StuffPeople { get; set; } = new HashSet<StuffPersonal>();

		#endregion
	}
	// EditAfterExtractingConfigs
}