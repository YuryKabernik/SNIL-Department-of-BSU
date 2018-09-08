using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IPeople
    {
        Task<IEnumerable<Leader>> GetHallOfFameLeadersAsync(int count, int langLCID);

        Task<PersonVM> GetPersonDescriptionAsync(int personId, int langLCID);
    }
}