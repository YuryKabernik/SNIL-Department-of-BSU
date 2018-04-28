namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Seminar
    {
        public int SeminarId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int SpeakerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime EventDate { get; set; }

        public int? DocFile { get; set; }

        public int ResponsiblePersonId { get; set; }

        public int? Topic { get; set; }

        public int Localisation { get; set; }

        public virtual Document Document { get; set; }

        public virtual Language Language { get; set; }

        public virtual Topic Topic1 { get; set; }

        public virtual ICollection<Person> People { get; set; } = new HashSet<Person>();
    }
}
