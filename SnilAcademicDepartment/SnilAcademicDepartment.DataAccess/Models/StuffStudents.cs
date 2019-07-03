using System;

namespace SnilAcademicDepartment.DataAccess.Models
{
	/// <summary>
	/// Table of SNIL staff of students.
	/// </summary>
	public class StuffStudents
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the student.
		/// </summary>
		/// <value>
		/// The student.
		/// </value>
		public Students Student { get; set; }
		/// <summary>
		/// Gets or sets the date entrance.
		/// </summary>
		/// <value>
		/// The date entrance.
		/// </value>
		public DateTime? DateEntrance { get; set; }
		/// <summary>
		/// Gets or sets the date departure.
		/// </summary>
		/// <value>
		/// The date departure.
		/// </value>
		public DateTime? DateDeparture { get; set; }
	}
}
