using System;

namespace SnilAcademicDepartment.DataAccess.Entities.BaseEntity
{
    /// <summary>
    /// Abstract model for all file type objects.
    /// </summary>
    public abstract class File : IFile
    {
        /// <summary>
        /// Gets and sets file id.
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Gets and sets file name.
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Gets and sets file size.
        /// </summary>
        public virtual Int64 Size { get; set; }
        /// <summary>
        /// Gets and sets file type.
        /// </summary>
        public virtual string Type { get; set; }
        /// <summary>
        /// Gets and sets file binary content.
        /// </summary>
        public virtual byte[] Content { get; set; }
    }
}
