namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Project
    {
        public int ProjectId { get; set; }

        public int CommonID { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public int? DocumentId { get; set; }

        public string ShortDescription { get; set; }

        public string ProjectStatus { get; set; }

        public int? ImageId { get; set; }

        public int Localisation { get; set; }

        public DateTime? CreationDate { get; set; }

        public virtual Document Document { get; set; }

        public virtual Image Image { get; set; }

        public virtual Language Language { get; set; }

        public virtual ICollection<Person> People { get; set; } = new HashSet<Person>();
    }
}
