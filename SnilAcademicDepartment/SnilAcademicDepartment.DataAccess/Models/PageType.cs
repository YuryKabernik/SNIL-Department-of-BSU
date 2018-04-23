namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PageType")]
    public partial class PageType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PageType()
        {
            PreViews = new HashSet<PreView>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PageTypeId { get; set; }

        [Column("PageType")]
        [StringLength(50)]
        public string PageType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PreView> PreViews { get; set; }
    }
}
