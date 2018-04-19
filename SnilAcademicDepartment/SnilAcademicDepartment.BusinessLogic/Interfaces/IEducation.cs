using SnilAcademicDepartment.BusinessLogic.Models;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    internal interface IEducation
    {
        PreView GetPagePreview();
        IEnumerable<KeyAreaBlock> GetKeyAreas();
    }
}