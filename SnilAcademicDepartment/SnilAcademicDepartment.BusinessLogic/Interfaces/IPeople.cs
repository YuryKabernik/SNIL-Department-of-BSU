using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface of getter person service.
    /// </summary>
    public interface IPeople
    {
        Task<IEnumerable<Leader>> GetHallOfFameLeadersAsync(int count, int langLCID);

        Task<PersonVM> GetPersonDescriptionAsync(int personId, int langLCID);

        Task<IEnumerable<PersonVM>> GetPersonsByDegreeAsync(string degreeName, int langLCID);
    }
}