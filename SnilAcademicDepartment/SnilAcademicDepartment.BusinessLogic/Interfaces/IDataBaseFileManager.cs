using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    /// <summary>
    /// Implement this interface to take files from database.
    /// </summary>
    public interface IDataBaseFileManager
    {
        /// <summary>
        /// Get file by id.
        /// </summary>
        /// <param name="id">File id number.</param>
        DocumentModel GetFileById(int id);
        
        /// <summary>
        /// Get file by name.
        /// </summary>
        /// <param name="name">Name of the file.</param>
        DocumentModel GetFileByName(string name);

        /// <summary>
        /// Get file by id async.
        /// </summary>
        /// <param name="id">File id number.</param>
        Task<DocumentModel> GetFileByIdAsync(int id);

        /// <summary>
        /// Get file by name async.
        /// </summary>
        /// <param name="name">Name of the file.</param>
        Task<DocumentModel> GetFileByNameAsync(string name);
    }
}