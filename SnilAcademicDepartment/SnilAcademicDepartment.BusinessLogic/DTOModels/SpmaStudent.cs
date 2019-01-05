using System;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
	public class SpmaStudent
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		public string FirstName { get; set; }
		/// <summary>
		/// Gets or sets the name of the secound.
		/// </summary>
		/// <value>
		/// The name of the secound.
		/// </value>
		public string SecoundName { get; set; }
		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		public string LastName { get; set; }
		/// <summary>
		/// Gets or sets the graduation year of student.
		/// </summary>
		/// <value>
		/// The graduation year.
		/// </value>
		public int GraduationYear { get; set; }
		/// <summary>
		/// Gets or sets the students group.
		/// </summary>
		/// <value>
		/// The students group.
		/// </value>
		public string StudentsGroup { get; set; }
		/// <summary>
		/// Gets or sets the students group.
		/// </summary>
		/// <value>
		/// The students group.
		/// </value>
		public string StudentsType { get; set; }
		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		/// <value>
		/// The image.
		/// </value>
		public byte[] Image { get; set; }
		/// <summary>
		/// Gets or sets the date entrance.
		/// </summary>
		/// <value>
		/// The date entrance.
		/// </value>
		public DateTime DateEntrance { get; set; }
		/// <summary>
		/// Gets or sets the date departure.
		/// </summary>
		/// <value>
		/// The date departure.
		/// </value>
		public DateTime DateDeparture { get; set; }
	}
}
