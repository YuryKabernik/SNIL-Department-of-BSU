namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Specialisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specialisation()
        {
            Lectures = new HashSet<Lecture>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpecialisationId { get; set; }

        [Column("Specialisation")]
        [Required]
        [StringLength(100)]
        public string Specialisation1 { get; set; }

        [Required]
        [StringLength(100)]
        public string Speciality { get; set; }

        public int Localiation { get; set; }

        public virtual Language Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
