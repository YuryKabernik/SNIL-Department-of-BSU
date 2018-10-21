namespace SnilAcademicDepartment.DataAccess.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Document
    {
        public int DocumentId { get; set; }

        public string DocumentName { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public byte[] FileContent { get; set; }

        public string FileTypeExtenction { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        public virtual ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();

        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();

    }
}
