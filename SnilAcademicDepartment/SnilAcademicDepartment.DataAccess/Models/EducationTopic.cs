namespace SnilAcademicDepartment.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EducationTopic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TopicId { get; set; }

        [StringLength(50)]
        public string TopicName { get; set; }

        public int EducationBlockType { get; set; }

        public virtual EducationBlock EducationBlock { get; set; }
    }
}
