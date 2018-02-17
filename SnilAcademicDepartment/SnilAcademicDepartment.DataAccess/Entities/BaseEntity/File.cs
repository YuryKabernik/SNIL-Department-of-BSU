using System;

namespace SnilAcademicDepartment.DataAccess.Entities.BaseEntity
{
    /// <summary>
    /// Abstract model for all file type objects.
    /// </summary>
    public abstract class File : IFile
    {
        public int FileId { get; set; }

        public string Name { get; set; }
        public Int64 Size { get; set; }
        public string Type { get; set; }
        public byte[] Content { get; set; }
    }
}
