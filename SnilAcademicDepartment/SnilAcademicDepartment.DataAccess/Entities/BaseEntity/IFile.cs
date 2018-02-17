using System;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    public interface IFile
    {
        int FileId { get; set; }

        string Name { get; set; }
        Int64 Size { get; set; }
        string Type { get; set; }
        byte[] Content { get; set; }
    }
}