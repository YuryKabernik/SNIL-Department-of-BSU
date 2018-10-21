namespace SnilAcademicDepartment.DataAccess.Models
{
    using System.Collections.Generic;

    public partial class Biography
    {
        public int BiographyId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Person> People { get; set; } = new HashSet<Person>();
    }
}
