namespace SnilAcademicDepartment.DataAccess.Models
{
    using System.Collections.Generic;

    public partial class Image
    {
        public int ImageId { get; set; }

        public string ImageName { get; set; }

        public byte[] Image1 { get; set; }

        public string ImageTypeExtenction { get; set; }

        public virtual ICollection<EducationBlock> EducationBlocks { get; set; } = new HashSet<EducationBlock>();

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

		public virtual ICollection<PreView> PreViews { get; set; } = new HashSet<PreView>();

		public virtual Person Person { get; set; }
	}
}
