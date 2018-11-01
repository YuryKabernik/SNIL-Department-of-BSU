using System.Collections.Generic;
using SnilAcademicDepartment.DataAccess.Models.EnumType;

namespace SnilAcademicDepartment.DataAccess.Models
{
	/// <summary>
	/// Table of types of students.
	/// </summary>
	public class StudentTypes
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the type unique identifier.
		/// </summary>
		/// <value>
		/// The type unique identifier.
		/// </value>
		public StudentType TypeUniqueId { get; set; }
		/// <summary>
		/// Gets or sets the name of the type.
		/// </summary>
		/// <value>
		/// The name of the type.
		/// </value>
		public string TypeName { get; set; }

		/// <summary>
		/// Gets or sets the student one-to-many relationship.
		/// </summary>
		/// <value>
		/// The student.
		/// </value>
		public ICollection<Students> Students { get; set; } = new HashSet<Students>();
	}
}
