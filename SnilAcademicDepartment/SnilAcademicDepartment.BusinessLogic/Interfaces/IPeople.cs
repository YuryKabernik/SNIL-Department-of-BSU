using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.Common.Enumerations;
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

        Task<IEnumerable<T>> GetPersonsByDegreeAsync<T>(DegreeEnum degreeName, int langLCID);

        Task<IEnumerable<T>> GetPersonsByAcademicTitleAsync<T>(AcademicTitleEnum academicTitleName, int langLCID);

        Task<IEnumerable<T>> GetPersonsByProfessionStatusAsync<T>(ProfessionStatusEnum professionStatusName, int langLCID);
    }
}