using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface of the main service methods.
    /// </summary>
    public interface IService
    {
        PreViewModel GetPagePreview(string pageType, int langLCID);
        IEnumerable<PreViewModel> GetPagePreviews(string pageType, int langLCID);
    }
}
