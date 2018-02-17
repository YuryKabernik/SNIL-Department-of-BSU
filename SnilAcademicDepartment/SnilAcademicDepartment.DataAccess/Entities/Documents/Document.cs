using System;
using SnilAcademicDepartment.DataAccess.Entities.BaseEntity;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of document in database.
    /// </summary>
    public sealed class Document : File
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
