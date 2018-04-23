namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lecture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lecture()
        {
            PersonLectures = new HashSet<PersonLecture>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LectureId { get; set; }

        [Required]
        [StringLength(50)]
        public string LectureName { get; set; }

        public int SpesialisationId { get; set; }

        [Required]
        public string Description { get; set; }

        public int Localisation { get; set; }

        public virtual Language Language { get; set; }

        public virtual Specialisation Specialisation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonLecture> PersonLectures { get; set; }
    }
}
