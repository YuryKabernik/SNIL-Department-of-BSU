using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess
{
    public partial class Person
    {
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string SecoundName { get; set; }

        public string FathersName { get; set; }

        public string ProfessionStatus { get; set; }

        public string Degree { get; set; }

        public string AcademicTitle { get; set; }

        public int Biography { get; set; }

        public string PersonalInterests { get; set; }

        public Image Image { get; set; }

        public int Localisation { get; set; }

        // Внешние связи

        public virtual Biography Biography1 { get; set; }

        public virtual ICollection<HallOfFame> HallOfFames { get; set; } = new HashSet<HallOfFame>();

        public virtual Language Language { get; set; }

        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        public virtual ICollection<Seminar> Seminars { get; set; } = new HashSet<Seminar>();

        public virtual ICollection<Lecture> Lectures { get; set; } = new HashSet<Lecture>();
    }
    // EditAfterExtractingConfigs
}
