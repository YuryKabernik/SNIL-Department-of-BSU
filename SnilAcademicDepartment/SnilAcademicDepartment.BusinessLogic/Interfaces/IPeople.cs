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

        Task<IEnumerable<T>> GetPersonsByDegreeAsync<T>(string degreeName, int langLCID);

        Task<IEnumerable<T>> GetPersonsByAcademicTitleAsync<T>(string degreeName, int langLCID);

        Task<IEnumerable<T>> GetPersonsByProfessionStatusAsync<T>(string degreeName, int langLCID);
    }
}