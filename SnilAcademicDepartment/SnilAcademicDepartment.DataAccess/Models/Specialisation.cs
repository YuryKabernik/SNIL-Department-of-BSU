using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Models
{
    public partial class Specialisation
    {
        public int SpecialisationId { get; set; }

        public string SpecialisationName { get; set; }

        public string Speciality { get; set; }

        public int Localiation { get; set; }

        public virtual Language Language { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();
    }
}
