namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Seminar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seminar()
        {
            People = new HashSet<Person>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }
    }
}
