using SnilAcademicDepartment.BusinessLogic.Models;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IHistory
    {
        IEnumerable<PreView> PreViews(string previewType);
    }
}