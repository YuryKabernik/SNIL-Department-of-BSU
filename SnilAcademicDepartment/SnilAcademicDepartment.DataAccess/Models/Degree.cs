namespace SnilAcademicDepartment.DataAccess.Models
{
	/// <summary>
	/// Degree table.
	/// </summary>
	public class Degree
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the unique code.
		/// </summary>
		/// <value>
		/// The unique code.
		/// </value>
		public int UniqueCode { get; set; }
		/// <summary>
		/// Gets or sets the degree naming.
		/// </summary>
		/// <value>
		/// The degree naming.
		/// </value>
		public string DegreeNaming { get; set; }
	}
}