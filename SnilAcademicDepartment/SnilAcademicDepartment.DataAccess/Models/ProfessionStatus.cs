namespace SnilAcademicDepartment.DataAccess.Models
{
	/// <summary>
	/// Profession status table.
	/// </summary>
	public class ProfessionStatus
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the unique code as EnumType int value.
		/// </summary>
		/// <value>
		/// The unique code.
		/// </value>
		public int UniqueCode { get; set; }
		/// <summary>
		/// Gets or sets the status naming in specific language.
		/// </summary>
		/// <value>
		/// The status naming.
		/// </value>
		public string StatusNaming { get; set; }
	}
}
