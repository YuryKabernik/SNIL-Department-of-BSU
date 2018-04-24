using SnilAcademicDepartment.BusinessLogic.Models;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IIndex
    {
        IEnumerable<PreView> GetIndexPreViews();
        IEnumerable<PreView> GetIndexPreRolls();
    }
}