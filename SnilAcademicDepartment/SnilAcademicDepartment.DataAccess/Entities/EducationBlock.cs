using System.Collections.Generic;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Entity of the education block.
    /// </summary>
    public class EducationBlock
    {
        /// <summary>
        /// Gets and sets education block id.
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// Gets and sets picture of education block.
        /// </summary>
        public virtual Image Picture { get; set; }
        /// <summary>
        /// Gets and sets shot discription of education block.
        /// </summary>
        public virtual string ShortDiscription { get; set; }
        /// <summary>
        /// Gets and sets tags of education block.
        /// </summary>
        public virtual ICollection<string> Tags { get; set; }
    }
}
