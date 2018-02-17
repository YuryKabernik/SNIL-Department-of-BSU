using System;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Interface for all file types.
    /// </summary>
    public interface IFile
    {
        /// <summary>
        /// Gets and sets file id.
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Gets and sets file name.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Gets and sets file size.
        /// </summary>
        Int64 Size { get; set; }
        /// <summary>
        /// Gets and sets file type.
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// Gets and sets file binary content.
        /// </summary>
        byte[] Content { get; set; }
    }
}