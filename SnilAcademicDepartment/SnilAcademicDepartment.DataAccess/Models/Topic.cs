namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Topic
    {
        public int TopicId { get; set; }

        public string TopicName { get; set; }

        public virtual ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();
    }
}
