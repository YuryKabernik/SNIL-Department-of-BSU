namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HallOfFame")]
    public partial class HallOfFame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoodPersonId { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
