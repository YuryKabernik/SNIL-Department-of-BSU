using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface of the main service methods.
    /// </summary>
    public interface IService
    {
        PreViewModel GetPagePreview(string pageType, int langLCID);
        IEnumerable<PreViewModel> GetPagePreviews(string pageType, int langLCID);

        Task<PreViewModel> GetPagePreviewAsync(string pageType, int langLCID);
        Task<IEnumerable<PreViewModel>> GetPagePreviewsAsync(string pageType, int langLCID);
    }
}
