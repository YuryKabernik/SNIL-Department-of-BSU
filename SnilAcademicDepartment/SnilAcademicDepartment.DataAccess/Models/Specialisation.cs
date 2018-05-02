using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SnilAcademicDepartment.DataAccess
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
