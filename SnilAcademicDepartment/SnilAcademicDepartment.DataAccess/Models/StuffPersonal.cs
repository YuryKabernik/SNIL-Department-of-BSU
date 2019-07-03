using System;

namespace SnilAcademicDepartment.DataAccess.Models
{
	/// <summary>
	/// Table of SNIL head staff as people.
	/// </summary>
	public class StuffPersonal
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the person identifier.
		/// </summary>
		/// <value>
		/// The person identifier.
		/// </value>
		public Person PersonId { get; set; }
		/// <summary>
		/// Gets or sets the assignment date.
		/// </summary>
		/// <value>
		/// The assignment date.
		/// </value>
		public DateTime? AssignmentDate { get; set; }
		/// <summary>
		/// Gets or sets the release date.
		/// </summary>
		/// <value>
		/// The release date.
		/// </value>
		public DateTime? ReleaseDate { get; set; }
	}
}
