using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Models
{
    public partial class Lecture
    {
        public int LectureId { get; set; }

        public string LectureName { get; set; }

        public string LectureType { get; set; }

        public int SpesialisationId { get; set; }

        public string Description { get; set; }

        public int? DocumentId { get; set; }

        public virtual Document Document { get; set; }

        public int Localisation { get; set; }

        public virtual Language Language { get; set; }

        public virtual Specialisation Specialisation { get; set; }

        public virtual ICollection<Person> People { get; set; } = new HashSet<Person>();
    }
}
