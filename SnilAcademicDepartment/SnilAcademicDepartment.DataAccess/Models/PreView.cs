namespace SnilAcademicDepartment.DataAccess.Models
{
    public partial class PreView
    {
        public int PreViewId { get; set; }

        public int PageType { get; set; }

        public string ShortDescription { get; set; }

        public string Header { get; set; }

		public Image Image { get; set; }

		public int? Localisation { get; set; }

        public virtual Language Language { get; set; }

        public virtual PageType PageTypeName { get; set; }
    }
}
