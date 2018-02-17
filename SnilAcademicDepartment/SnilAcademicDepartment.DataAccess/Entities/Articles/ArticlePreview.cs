namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of article preview.
    /// </summary>
    public class ArticlePreview
    {
        public Image Picture { get; set; }
        public string ShortDiscription { get; set; }
        public string Header { get; set; }
    }
}
