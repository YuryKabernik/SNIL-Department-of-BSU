using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Models
{
    public partial class Topic
    {
        public int TopicId { get; set; }

        public string TopicName { get; set; }

        public virtual ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();
    }
}
