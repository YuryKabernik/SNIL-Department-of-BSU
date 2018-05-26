namespace SnilAcademicDepartment.DataAccess
{
    using System.Collections.Generic;

    public partial class Image
    {
        public int ImageId { get; set; }

        public string ImageName { get; set; }

        public byte[] Image1 { get; set; }

        public virtual ICollection<EducationBlock> EducationBlocks { get; set; } = new HashSet<EducationBlock>();

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        public Person Person { get; set; }
    }
}
