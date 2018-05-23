using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IEducation
    {
        /// <summary>
        /// Search key areas of education blocks.
        /// </summary>
        /// <param name="pages">Number of pages to get.</param>
        /// <param name="LCID">Languahe code</param>
        /// <returns>Collection of education key areas.</returns>
        List<EducationBlockModel> GetKeyAreas(int pages, int lCID);

        /// <summary>
        /// Get education block by it's name.
        /// </summary>
        /// <param name="pages">Name of the education block.</param>
        /// <param name="LCID">Languahe code.</param>
        /// <returns>Education block as requested.</returns>
        EducationBlockModel GetEducationBlock(string blockName, int LCID);
    }
}