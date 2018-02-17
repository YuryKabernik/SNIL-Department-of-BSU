using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Entity of full page article.
    /// </summary>
    public class Article
    {
        /// <summary>
        ///  Gets and sets article id.
        /// </summary>
        public virtual string ArticleId { get; set; }
        /// <summary>
        /// Gets and sets the collection of images in current article.
        /// </summary>
        public virtual ICollection<Image> Pictures { get; set; }
        /// <summary>
        /// Gets and sets the collection of documents attached to current article.
        /// </summary>
        public virtual ICollection<Document> Documents { get; set; }
        /// <summary>
        /// Gets and sets article text.
        /// </summary>
        public virtual string ArticleText { get; set; }
        /// <summary>
        /// Gets and sets article header.
        /// </summary>
        public virtual string Header { get; set; }
        /// <summary>
        /// Gets and sets article authors.
        /// </summary>
        public virtual ICollection<Author> Authors { get; set; }
    }
}
