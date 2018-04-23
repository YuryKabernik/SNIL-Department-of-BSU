using System;
using SnilAcademicDepartment.DataAccess.Entities.BaseEntity;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of document file.
    /// </summary>
    public class Document : File
    {
        /// <summary>
        /// Gets and sets <see cref="bool"/> if document is deleter if empty.
        /// </summary>
        public virtual bool IsDeleted { get; set; }
        /// <summary>
        /// Gets and sets <see cref="DateTime"/> of file creation. 
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }
        /// <summary>
        /// Gets and sets <see cref="DateTime"/> of file modification. 
        /// </summary>
        public virtual DateTime ModifiedOn { get; set; }
    }
}
