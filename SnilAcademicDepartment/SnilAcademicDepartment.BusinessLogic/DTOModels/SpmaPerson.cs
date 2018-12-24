using System;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
	public class SpmaPerson : PersonVM
	{
		/// <summary>
		/// Gets or sets the assignment date.
		/// </summary>
		/// <value>
		/// The assignment date.
		/// </value>
		public DateTime AssignmentDate { get; set; }
		/// <summary>
		/// Gets or sets the release date.
		/// </summary>
		/// <value>
		/// The release date.
		/// </value>
		public DateTime ReleaseDate { get; set; }
	}
}