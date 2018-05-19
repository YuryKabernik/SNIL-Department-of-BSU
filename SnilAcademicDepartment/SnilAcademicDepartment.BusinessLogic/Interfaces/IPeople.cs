using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IPeople
    {
        IEnumerable<Leader> GetHallOfFameLeaders();

        IEnumerable<PreViewModel> GetPreViews();
    }
}