using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of authors.
    /// </summary>
    public class Author
    {
        /// <summary>
        ///  Gets and sets author id.
        /// </summary>
        public string AuthorId { get; set; }
        /// <summary>
        /// Gets and sets author's first name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets and sets author's secound name.
        /// </summary>
        public string SecoundName { get; set; }
        /// <summary>
        /// Gets and sets author's position in SNIL academic department.
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Gers and sets author's articles. 
        /// </summary>
        public ICollection<Article> Articles { get; set; }
    }
}