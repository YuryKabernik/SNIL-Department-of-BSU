using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SnilAcademicDepartment.DataAccess
{
    [Table("EducationBlock")]
    public partial class EducationBlock
    {
        public int BlockId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Image { get; set; }

        public int Localisation { get; set; }

        public virtual Image Image1 { get; set; }

        public virtual Language Language { get; set; }

        public virtual ICollection<EducationTopic> EducationTopics { get; set; } = new HashSet<EducationTopic>();
    }
}
