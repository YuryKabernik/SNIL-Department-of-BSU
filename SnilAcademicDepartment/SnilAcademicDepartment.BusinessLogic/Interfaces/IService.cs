using SnilAcademicDepartment.BusinessLogic.Models;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface of the main service methods.
    /// </summary>
    public interface IService
    {
        PreView GetPagePreview(string pageType, int langLCID);
        IEnumerable<PreView> GetPagePreviews(string pageType);
    }
}
