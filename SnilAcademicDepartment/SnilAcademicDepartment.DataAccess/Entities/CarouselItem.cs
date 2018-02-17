namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Entity of the home page preroles.
    /// </summary>
    public class CarouselItem
    {
        /// <summary>
        /// Gets and sets carousel item id.
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// Gets and sets image of article preview.
        /// </summary>
        public virtual Image Picture { get; set; }
        /// <summary>
        /// Gets and sets header of article preview.
        /// </summary>
        public virtual string Header { get; set; }
        /// <summary>
        /// Gets and sets short discription of article preview.
        /// </summary>
        public virtual string ShortDiscription { get; set; }
    }
}
