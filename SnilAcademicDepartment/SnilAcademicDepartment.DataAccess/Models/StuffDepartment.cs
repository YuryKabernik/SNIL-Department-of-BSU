using System;
using SnilAcademicDepartment.Common.Enumerations.DepartmentStaff;

namespace SnilAcademicDepartment.DataAccess.Models
{
	/// <summary>
	/// Department stuff table.
	/// </summary>
	public class StuffDepartment
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
		/// Gets or sets the data assign.
		/// </summary>
		/// <value>
		/// The data assign.
		/// </value>
		public DateTime DataAssign { get; set; }
		/// <summary>
		/// Gets or sets the date release.
		/// </summary>
		/// <value>
		/// The date release.
		/// </value>
		public DateTime DateRelease { get; set; }
		/// <summary>
		/// 
		/// </summary>
		/// <value>
		/// The date release.
		/// </value>
		public PedagogicalStaffType StaffType { get; set; }
	}
}
