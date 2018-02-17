using SnilAcademicDepartment.DataAccess.Entities.BaseEntity;
using System;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    public sealed class Image : File
    {
        public Int64 Width { get; set; }
        public Int64 Hight { get; set; }
    }
}
