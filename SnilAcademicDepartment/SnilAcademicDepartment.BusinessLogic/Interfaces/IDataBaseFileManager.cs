using SnilAcademicDepartment.BusinessLogic.DTOModels;

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
    }
}