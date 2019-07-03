using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SnilAcademicDepartment.Common.Enumerations;

namespace SnilAcademicDepartment.DataAccess.Models.Education
{
	[Table("Diplomas")]
	public class Diploma
	{
		/// <summary>
		/// Gets or sets the diploma identifier.
		/// </summary>
		/// <value>
		/// The diploma identifier.
		/// </value>
		public int DiplomaId { get; set; }

        /// <summary>
        /// Gets or sets the name.
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
		/// Gets or sets the language.
		/// </summary>
		/// <value>
		/// The language.
		/// </value>
		public int LanguageId { get; set; }

		/// <summary>
		/// Gets or sets the protection date.
		/// </summary>
		/// <value>
		/// The protection date.
		/// </value>
		public DateTime ProtectionDate { get; set; }

		#region Table Dependencies

		public virtual Language Localization { get; set; }

		public virtual ICollection<Person> Teachers { get; set; } = new HashSet<Person>();

		#endregion
	}
}
