using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IEducation
    {
        /// <summary>
        /// Search key areas of education blocks.
        /// </summary>
        /// <param name="pages">Number of the pages to get.</param>
        /// <param name="lcid">Language code</param>
        /// <returns>Collection of education key areas.</returns>
        List<EducationBlockModel> GetKeyAreas(int pages, int lcid);

        /// <summary>
        /// Async search key areas of education blocks.
        /// </summary>
        /// <param name="pages">Number of the pages to get.</param>
        /// <param name="lcid">Language code</param>
        /// <returns>Collection of education key areas.</returns>
        Task<List<EducationBlockModel>> GetKeyAreasAsync(int pages, int lcid);

        /// <summary>
        /// Get education block by it's name.
        /// </summary>
        /// <param name="pages">Name of the education block.</param>
        /// <param name="lcid">Language code.</param>
        /// <returns>Education block as requested.</returns>
        EducationBlockModel GetEducationBlock(string blockName, int lcid);

        /// <summary>
        /// Get education block by it's id.
        /// </summary>
        /// <param name="pages">Id of the education block.</param>
        /// <param name="lcid">Language code.</param>
        /// <returns>Education block by requested id.</returns>
        EducationBlockModel GetEducationBlockById(int educationBlockId, int lcid);

        /// <summary>
        /// Get education block by it's name.
        /// </summary>
        /// <param name="pages">Name of the education block.</param>
        /// <param name="lcid">Language code.</param>
        /// <returns>Education block as requested.</returns>
        Task<EducationBlockModel> GetEducationBlockAsync(string blockName, int lcid);

        /// <summary>
        /// Get education block by it's id.
        /// </summary>
        /// <param name="pages">Id of the education block.</param>
        /// <param name="lcid">Language code.</param>
        /// <returns>Education block by requested id.</returns>
        Task<EducationBlockModel> GetEducationBlockByIdAsync(int educationBlockId, int lcid);
    }
}