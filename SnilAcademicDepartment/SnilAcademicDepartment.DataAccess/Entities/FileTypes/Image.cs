using SnilAcademicDepartment.DataAccess.Entities.BaseEntity;
using System;

namespace SnilAcademicDepartment.DataAccess.Entities
{
    /// <summary>
    /// Model of image.
    /// </summary>
    public class Image : File
    {
        /// <summary>
        /// Gets and sets image width.
        /// </summary>
        public virtual Int64 Width { get; set; }
        /// <summary>
        /// Gets and sets image hight.
        /// </summary>
        public virtual Int64 Hight { get; set; }
    }
}
