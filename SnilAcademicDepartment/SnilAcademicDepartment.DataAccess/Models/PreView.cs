namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PreView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PreViewId { get; set; }

        public int PageType { get; set; }

        [Column(TypeName = "text")]
        public string ShortDescription { get; set; }

        [StringLength(50)]
        public string Header { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Image { get; set; }

        public int? Localisation { get; set; }

        public virtual Language Language { get; set; }

        public virtual PageType PageType1 { get; set; }
    }
}
