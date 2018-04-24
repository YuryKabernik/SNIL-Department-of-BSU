using SnilAcademicDepartment.BusinessLogic.Models;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IPeople
    {
        IEnumerable<Leader> GetHallOfFameLeaders();

        IEnumerable<PreView> GetPreViews();
    }
}