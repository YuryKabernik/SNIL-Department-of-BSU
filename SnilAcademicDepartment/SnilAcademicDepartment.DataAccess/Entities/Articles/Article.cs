using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of main article.
    /// </summary>
    public class Article
    {
        public string ArticleId { get; set; }

        public ICollection<Image> Pictures { get; set; }
        public ICollection<Document> Documents { get; set; }
        public string ArticleText { get; set; }
        public string Header { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
