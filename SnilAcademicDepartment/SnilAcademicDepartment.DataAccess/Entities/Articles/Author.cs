using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of authors.
    /// </summary>
    public class Author
    {
        public string AuthorId { get; set; }
        public string FirstName { get; set; }
        public string SecoundName { get; set; }
        public string Position { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}