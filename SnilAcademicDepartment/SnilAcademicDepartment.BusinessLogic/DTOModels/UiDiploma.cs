using SnilAcademicDepartment.Common.Enumerations;
using System;

namespace SnilAcademicDepartment.BusinessLogic.DTOModels
{
	/// <summary>
	/// Class of the Doploma for the UI render.
	/// </summary>
	public class UiDiploma
	{
		/// <summary>
		/// Gets or sets the diploma identifier.
		/// </summary>
		/// <value>
		/// The diploma identifier.
		/// </value>
		public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public DiplomaTypes Type { get; set; }

		/// <summary>
		/// Gets or sets the descriptions.
		/// </summary>
		/// <value>
		/// The descriptions.
		/// </value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the protection date.
		/// </summary>
		/// <value>
		/// The protection date.
		/// </value>
		public DateTime ProtectionDate { get; set; }
	}
}