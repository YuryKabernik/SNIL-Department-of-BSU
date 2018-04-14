namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of article preview.
    /// </summary>
    public class ArticlePreview
    {
        /// <summary>
        ///  Gets and sets article preview id.
        /// </summary>
        public virtual string ArticlePreviewId { get; set; }
        /// <summary>
        /// Gets and sets image of an article preview.
        /// </summary>
        public virtual Image Picture { get; set; }
        /// <summary>
        /// Gets and sets short disccription of an article preview.
        /// </summary>
        public virtual string ShortDiscription { get; set; }
        /// <summary>
        /// Gets and sets header of an article preview.
        /// </summary>
        public virtual string Header { get; set; }
    }
}
