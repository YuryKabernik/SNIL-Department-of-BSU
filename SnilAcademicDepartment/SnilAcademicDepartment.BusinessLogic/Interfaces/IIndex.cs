using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IIndex
    {
        IEnumerable<PreViewModel> GetIndexPreViews();
        IEnumerable<PreViewModel> GetIndexPreRolls();
    }
}