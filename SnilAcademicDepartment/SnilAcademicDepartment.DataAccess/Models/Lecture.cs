using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess
{
    public partial class Lecture
    {
        public int LectureId { get; set; }

        public string LectureName { get; set; }

        public int SpesialisationId { get; set; }

        public string Description { get; set; }

        public int Localisation { get; set; }

        public virtual Language Language { get; set; }

        public virtual Specialisation Specialisation { get; set; }

        public virtual ICollection<Person> People { get; set; } = new HashSet<Person>();
    }
}
