namespace SnilAcademicDepartment.DataAccess.Models
{
	/// <summary>
	/// AcademicTitle table.
	/// </summary>
	public class AcademicTitle
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
		/// Gets or sets the academic title naming.
		/// </summary>
		/// <value>
		/// The academic title naming.
		/// </value>
		public string AcademicTitleNaming { get; set; }
	}
}