namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            HallOfFames = new HashSet<HallOfFame>();
            PersonLectures = new HashSet<PersonLecture>();
            Projects = new HashSet<Project>();
            Seminars = new HashSet<Seminar>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        [Required]
        [StringLength(10)]
        public string PersonName { get; set; }

        [Required]
        [StringLength(50)]
        public string SecoundName { get; set; }

        [Required]
        [StringLength(20)]
        public string FathersName { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfessionStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Degree { get; set; }

        [Required]
        [StringLength(50)]
        public string AcademicTitle { get; set; }

        public int Biography { get; set; }

        [StringLength(50)]
        public string PersonalInterests { get; set; }

        public int? ImageId { get; set; }

        public int Localisation { get; set; }

        public virtual Biography Biography1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HallOfFame> HallOfFames { get; set; }

        public virtual Language Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonLecture> PersonLectures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seminar> Seminars { get; set; }
    }
}
